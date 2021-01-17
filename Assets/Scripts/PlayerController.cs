using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    
    //  todo work-out why sometimes slow on first play of scene
    
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] private float controlSpeed = 10f;
    [Tooltip("In ms^-1")][SerializeField] private float xRange = 6f;
    [Tooltip("In ms^-1")][SerializeField] private float yRange = 4f;

    [Header("Screen-Position-Based")]
    [SerializeField] private float positionPitchFactor = -5f;
    [SerializeField] private float positionYawFactor = 5f;
    
    [Header("Control-throw-Based")]
    [SerializeField] private float controlRollFactor = -30f;
    [SerializeField] private float controlPitchFactor = -20f;
    
    private float m_XThrow, m_YThrow;

    private bool m_IsControlEnabled = true;
    // Update is called once per frame

    void OnPlayerDeath() // Called by string reference
    {
        print("Controls are Stopping");
        m_IsControlEnabled = false;
    }
    void Update()
    {
        if (m_IsControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void ProcessRotation()
    {
        var pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        var pitchDueToControlThrow = m_YThrow * controlPitchFactor;
        
        var pitch = pitchDueToPosition + pitchDueToControlThrow;
        
        var yaw = transform.localPosition.x * positionYawFactor;
        var roll = m_XThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    private void ProcessTranslation()
    {
        m_XThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        var xOffset = (m_XThrow * controlSpeed) * Time.deltaTime;

        m_YThrow = CrossPlatformInputManager.GetAxis("Vertical");
        var yOffset = (m_YThrow * controlSpeed) * Time.deltaTime;

        var localPosition = transform.localPosition;

        var rawXPos = localPosition.x + xOffset;
        var xPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        var rawYPos = localPosition.y + yOffset;
        var yPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        localPosition = new Vector3(xPos, yPos, localPosition.z);
        transform.localPosition = localPosition;
    }
}

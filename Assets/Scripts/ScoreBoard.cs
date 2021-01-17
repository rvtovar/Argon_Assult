using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{ 
    private int m_Score;

    private Text m_ScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        m_ScoreText = GetComponent<Text>();
        m_ScoreText.text = m_Score.ToString();
    }

    public void ScoreHit(int scorePerHit)
    {
        m_Score += scorePerHit;
        m_ScoreText.text = m_Score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

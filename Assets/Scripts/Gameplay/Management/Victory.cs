using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Victory : MonoBehaviour
{
    
    public float finalScore;
    public TMP_Text FinalScore;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            finalScore = Score.score;
            FinalScore.text = "Final Score: " + finalScore.ToString("0.00");
            Time.timeScale = 0f;

            
            GameManager.Instance.Win();
        }
    }
}

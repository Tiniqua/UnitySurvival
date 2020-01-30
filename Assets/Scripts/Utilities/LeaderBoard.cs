using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    private const float templateHeight = 350f;
    string strRank;
    private int score;
    private string playerName = "AAA";
    
    // Could create temp array to hold scores, create the array from a text file of scores (array position for line in text file, split line by space to seperate name and score), bubble sort array, do for loop to grab first 10 elements (top 10 scores) and output to leaderboard

    private void Awake()
    {
        Debug.Log("START");
        for (int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            entryTransform.gameObject.SetActive(true);

            TMP_Text[] textChildren = entryTransform.GetComponentsInChildren<TMP_Text>();

            int rank = i + 1;

            switch (rank)
            {
                default: strRank = rank + "th"; break;
                case 1: strRank = "1st"; break;
                case 2: strRank = "2nd"; break;
                case 3: strRank = "3rd"; break;
            }

            //Debug.Log("looping");
            foreach (TMP_Text text in textChildren)
            {
                if (text.name == "posText")
                    text.text = strRank;
                if (text.name == "scoreText")
                {
                    score = Random.Range(0, 100);
                    
                    text.text = score.ToString();
                }
                if (text.name == "nameText")
                    text.text = playerName;
            }
        }
    }
}
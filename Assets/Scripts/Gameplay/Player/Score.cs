using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text scoreObject;
    public static float score;

    void Start()
    {
        score = 0;    
    }

    void Update()
    {
        score += Time.deltaTime;
        scoreObject.text = "Score: " + score.ToString("0.00");
    }
}

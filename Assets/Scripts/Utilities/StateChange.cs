using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChange : MonoBehaviour
{
    


    public void mainMenu()
    {
        GameManager.Instance.MainMenu();
    }

    public void viewRules()
    {
        GameManager.Instance.ShowRules();
    }

    public void viewLeaderboard()
    {
        GameManager.Instance.ShowLeaderboard();
    }

    public void playGame()
    {
        GameManager.Instance.PlayGame();
    }

    public static void Win()
    {
        GameManager.Instance.Win();
    }

    //public void showScore()
    //{
    //    Transform WinInstance = Instantiate(winScreenPrefab).transform;
    //}
}

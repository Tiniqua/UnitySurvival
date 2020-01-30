using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {

    
    public AudioSource playerDeath;
    enum GameState { MENU, START, IN_GAME, RULES, GAME_OVER, LEADERBOARD,WIN };
    private GameState gameState;
    [SerializeField] private GameState startState = GameState.START; // Exists to enable individual level testing


    [SerializeField]
    private GameObject gameOverPrefab;
    public GameObject winScreenPrefab;
    public GameObject Player;



    static private GameManager instance = null;

    // Lets other scripts find the instane of the game manager
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public static GameManager WinInstance
    {
        get
        {
            return instance;
        }
    }

    

    // Ensure there is only one instance of this object in the game
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    void Start()
    {
        gameState = startState;
        
    }

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnChangeState(GameState newState)
    {
        if (gameState != newState)
        {
            switch (newState)
            {
                case GameState.START:
                    break;

                case GameState.IN_GAME:

                    Time.timeScale = 1; // Set timescale to be a normal rate 
                    Application.LoadLevel("Game"); // Load the 'Game' scene

                    Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the game screen
                    Cursor.visible = false;

                    break;

                case GameState.RULES:
                    Application.LoadLevel("Rules");

                    break;

                case GameState.GAME_OVER:

                    // DO BLOOD ANIMATION HERE
                    Player.GetComponent<ParticleSystem>().Play();

                    StartCoroutine(stopBlood());
                    
                    break;

                case GameState.WIN:

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    EnableInput(false);
                    Time.timeScale = 0;
                    Transform WinInstance = Instantiate(winScreenPrefab).transform;

                    //StateChange.Instance.showScore();

                    //Button RestartButton2 = WinInstance.Find("RestartButton").GetComponent<Button>();
                    //RestartButton2.onClick.AddListener(() => PlayGame());
                    //Button QuitButton2 = WinInstance.Find("QuitButton").GetComponent<Button>();
                    //QuitButton2.onClick.AddListener(() => QuitGame());

                    break;

                case GameState.MENU:

                    Application.LoadLevel("Start");

                    break;

                case GameState.LEADERBOARD:

                    Application.LoadLevel("Leaderboard");

                    break;
            }

            gameState = newState;
        }
    }

    IEnumerator stopBlood()
    {
        //Debug.Log("Test");
        EnableInput(false);
        yield return new WaitForSeconds(2f);

        Cursor.lockState = CursorLockMode.None; // unlock the cursor for the menu
        Cursor.visible = true;
        
         
        Time.timeScale = 0; // Pause the game by setting timescale to 0 to stop AI behaviour
        Transform instance = Instantiate(gameOverPrefab).transform; // Instantiate the GameOver menu prefab

        Button restartButton = instance.Find("RestartButton").GetComponent<Button>();
        restartButton.onClick.AddListener(() => PlayGame());
        Button quitButton = instance.Find("QuitButton").GetComponent<Button>();
        quitButton.onClick.AddListener(() => QuitGame());
    }

    private void EnableInput(bool input)
    {
        // Find the player object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<FirstPersonController>().enabled = input;
        //player.GetComponentInChildren<Gun>().enabled = input;

    }

    public void ShowLeaderboard()
    {
        OnChangeState(GameState.LEADERBOARD);
    }

    public void PlayGame()
    {
        OnChangeState(GameState.IN_GAME);
    }

    public void Win()
    {
        OnChangeState(GameState.WIN);
    }

    public void GameOver()
    {
        OnChangeState(GameState.GAME_OVER);
    }

    public void ShowRules()
    {
        OnChangeState(GameState.RULES);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        OnChangeState(GameState.MENU);
    }
    

}

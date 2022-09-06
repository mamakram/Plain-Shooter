using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Player player;
    public Button resumeButton;
    public Button settingsButton;
    public Button quitButton;
    public Button quitButton2;
    public Button restartButton;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    private bool gameOver = false;

    public static float maxX;
    public static float maxY;
    public static bool paused = false;

   
    void Awake()
    {
        maxY = Camera.main.GetComponent<Camera>().orthographicSize;
        maxX = maxY * Screen.width / Screen.height;
    }


    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
        quitButton2.onClick.AddListener(QuitGame);
        //input = InputController.instance;
        pausePanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        Time.timeScale = 1;
        paused = false;
        //Instantiate(powerUps[2]);
        //GetComponent<EnemySpawner>().StopDrones();
        //GetComponent<EnemySpawner>().SpawnBoss();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (paused) { ResumeGame(); }
                else { PauseGame(); }
            }
            if (player.Dead()) { GameOver(); }
        }
    }

    private void PauseGame ()
    {
        Time.timeScale = 0;
        pausePanel.gameObject.SetActive(true);
        AudioListener.pause = true;
        paused = true;
    }

    public void GameOver()
    {
        gameOver = true;
        player.gameObject.SetActive(false);
        GetComponent<MusicController>().GameOverSound();
        gameOverPanel.gameObject.SetActive(true);
    }

    private void ResumeGame ()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pausePanel.gameObject.SetActive(false);
        paused = false;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Game");
        Destroy(this);
    }

    void QuitGame(){
        SceneManager.LoadScene("Main Menu");
        Destroy(this);
    }
}

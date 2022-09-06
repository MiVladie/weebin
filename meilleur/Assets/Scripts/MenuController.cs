using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject ContinueButton;
    public GameObject ExitButton;

    private bool canContinue = false;
    private bool canExit = false;

    void Start()
    {
        AnalyseProgress();
    }

    void Update()
    {
        ListenKeys();
    }

    void ListenKeys()
    {
        // New Game
        if(Input.GetKeyDown(KeyCode.N))
        {
            NewGame();
        }
        
        // Continue
        if(canContinue && Input.GetKeyDown(KeyCode.E))
        {
            ContinueGame();
        }
        
        // Scoreboard
        if(Input.GetKeyDown(KeyCode.S))
        {
            Scoreboard();
        }

        // Exit
        if(canExit && Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }

    void AnalyseProgress()
    {
        if(!PlayerPrefs.HasKey("RANK")) {
            PlayerPrefs.SetInt("RANK", 0);
            PlayerPrefs.SetString("SCOREBOARD", "");
            PlayerPrefs.SetString("LAST_SCORE", "");
        }

        canContinue = PlayerPrefs.HasKey("LEVEL") &&
            PlayerPrefs.HasKey("LIVES") &&
            (
                PlayerPrefs.GetInt("LEVEL") != 1 ||
                PlayerPrefs.GetInt("CHECKPOINT") != 0
            );

        canExit = Application.platform != RuntimePlatform.WebGLPlayer;

        ContinueButton.SetActive(canContinue);
        ExitButton.SetActive(canExit);
    }

    public void ContinueGame()
    {
        FindObjectOfType<AudioManager>()?.Play("Button");
        FindObjectOfType<QuizManager>()?.ApplyQuestions();

        SceneManager.LoadScene(PlayerPrefs.GetInt("LEVEL"));    
    }

    public void NewGame()
    {
        FindObjectOfType<AudioManager>()?.Play("Button");
        FindObjectOfType<QuizManager>()?.ApplyQuestions(true);

        int rank = PlayerPrefs.GetInt("RANK");

        switch(rank)
        {
            case 0:
                PlayerPrefs.SetInt("POINTS", 250);
                break;
                
            case 1:
                PlayerPrefs.SetInt("POINTS", 500);
                break;
                
            case 2:
                PlayerPrefs.SetInt("POINTS", 1000);
                break;
                
            default:
                break;
        }

        PlayerPrefs.SetInt("LEVEL", 1);
        PlayerPrefs.SetInt("CHECKPOINT", 0);
        PlayerPrefs.SetInt("LIVES", 9);
        PlayerPrefs.SetInt("QUIZZES_ANSWERED", 0);

        SceneManager.LoadScene("Hetimiul");
    }

    public void Scoreboard()
    {
        SceneManager.LoadScene("Scoreboard");
    }

    public void Exit()
    {
        Application.Quit();
    }
    
}

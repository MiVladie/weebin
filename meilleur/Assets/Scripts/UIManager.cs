using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text[] lives;

    public GameObject popManager;

    void Start()
    {
        UpdateLives();
        AssignPopMenu();
    }

    void Update()
    {
        ListenKeys();
    }

    void ListenKeys()
    {
        // Pause
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }

    void UpdateLives()
    {
        int CURRENT_LIVES = PlayerPrefs.GetInt("LIVES");

        for(int i = 0; i < lives.Length; i++)
        {
            lives[i].text = CURRENT_LIVES.ToString();
        }
    }

    public void OpenMenu()
    {
        FindObjectOfType<AudioManager>()?.Play("Button");
        
        SceneManager.LoadScene("Menu");
    }

    void AssignPopMenu()
    {
        PopController[] pops = FindObjectsOfType<PopController>();

        for(int i = 0; i < pops.Length; i++)
        {
            pops[i].popManager = this.popManager;
        }
    }

}

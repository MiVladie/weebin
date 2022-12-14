using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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

    public void OpenMenu()
    {
        FindObjectOfType<AudioManager>()?.Play("Button");
        
        SceneManager.LoadScene("Menu");
    }

}

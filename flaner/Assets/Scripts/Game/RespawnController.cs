using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{
    private const float DURATION = 2f;

    void Start()
    {
        StartCoroutine(RespawnPlayer());
    }

    IEnumerator RespawnPlayer() 
    {
        yield return new WaitForSeconds(DURATION); 

        SceneManager.LoadScene(PlayerPrefs.GetInt("LEVEL"));
    }
}

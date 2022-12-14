using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Gameplay : MonoBehaviour
{
    public GameObject checkpoints;

    private PhotonView view;

    void Awake()
    {
        view = GetComponent<PhotonView>();
        checkpoints = GameObject.Find("Checkpoints");

        Spawn();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(!view.IsMine)
            return;

        switch(col.gameObject.tag) {
            case "Obstacle":
                ObstacleHit();
                break;

            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        switch(col.gameObject.tag) {
            case "Checkpoint":
                CheckpointHit(col);
                break;
            
            default:
                break;
        }
    }

    private void CheckpointHit(Collider col)
    {
        int checkpointIndex = col.gameObject.transform.GetSiblingIndex();

        col.gameObject.SetActive(false);

        PlayerPrefs.SetInt("CHECKPOINT", checkpointIndex);
    }

    private void ObstacleHit()
    {
        FindObjectOfType<AudioManager>()?.Play("Die");

        Spawn();
    }
    
    private void Spawn()
    {
        // Get current checkpoint
        int currentCheckpoint = PlayerPrefs.GetInt("CHECKPOINT");

        // Disabling all previous checkpoints
        for(int i = 0; i < currentCheckpoint; i++) 
        {
            checkpoints.transform.GetChild(i).gameObject.SetActive(false);
        }

        // Move player into the last checkpoint
        transform.position = checkpoints.transform.GetChild(currentCheckpoint).gameObject.transform.position;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

}

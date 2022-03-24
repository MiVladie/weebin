using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    public GameObject checkpoints;
    public Text objective;

    private bool isPlaying = false;

    void Awake()
    {
        Spawn();
    }


    public void onCutsceneEnd(string name)
    {
        switch (name)
        {
            // Hetimiul
            case "Appearing":
                objective.text = "Talk to Kitty";
                FindAndPlayDialogue("Informing");
                break;

            case "Congratulating":
                objective.text = "Talk to Kitty";
                FindAndPlayDialogue("Congratulating");
                break;
                
            case "Departing":
                NextLevel();
                break;
            
            // Cisius
            case "Observing":
                objective.text = "Rescue Kittilian";
                break;

            case "Appreciating":
                objective.text = "Talk to Kittilian";
                FindAndPlayDialogue("Appreciating");
                break;
                
            case "Taking":
                NextLevel();
                break;
            
            // Juseno
            case "Looking":
                objective.text = "Save Kittilian";
                break;

            case "Farewell":
                objective.text = "Talk to Kittilian";
                FindAndPlayDialogue("Farewell");
                break;

            case "Fading":
                RestartGame();
                break;
            
            default:
                break;
        }
    }

    public void onDialogueEnd(string name)
    {
        switch (name)
        {
            // Hetimiul
            case "Informing":
                objective.text = "Reach the end";
                FindAndPlayCutscene("Leaving");
                break;
                
            case "Congratulating":
                objective.text = "Leave the planet";
                FindAndPlayCutscene("Departing");
                break;

            // Cisius
            case "Appreciating":
                objective.text = "Leave the planet";
                FindAndPlayCutscene("Going");
                break;
                
            // Juseno
            case "Farewell":
                FindAndPlayCutscene("Fading");
                break;

            default:
                break;
        }
    }

    public void FindAndPlayCutscene(string name)
    {
        GameObject.Find("/Cutscenes/" + name + "/Trigger").GetComponent<TriggerCutscene>().Play();
    }
    
    public void FindAndPlayDialogue(string name)
    {
        GameObject.Find("/Instructions/" + name).transform.GetChild(1).GetComponent<Dialogue>().Begin();
    }

    private void OnCollisionEnter(Collision col)
    {
        switch(col.gameObject.tag) {
            case "Obstacle":
                ObstacleHit(col);
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
            
            case "Hairballs":
                GetComponent<PlayerController>().enableShooting = true;
                Destroy(col.gameObject);
                break;

            default:
                break;
        }
    }

    private void ObstacleHit(Collision col)
    {
        if(!isPlaying)
            return;

        isPlaying = false;

        int currentLives = PlayerPrefs.GetInt("LIVES") - 1;

        FindObjectOfType<AudioManager>()?.Play("Die");

        PlayerPrefs.SetInt("LIVES", currentLives);

        SceneManager.LoadScene("Respawn");
    }


    private void CheckpointHit(Collider col)
    {
        int checkpointIndex = col.gameObject.transform.GetSiblingIndex();

        col.gameObject.SetActive(false);

        PlayerPrefs.SetInt("CHECKPOINT", checkpointIndex);
    }
    
    public string GetObjective()
    {
        int level = PlayerPrefs.GetInt("LEVEL");
        int checkpoint = PlayerPrefs.GetInt("CHECKPOINT");

        if(level == 1)
        {
            if(checkpoint < 2)
                return "Go forwards";

            if(checkpoint >= 2)
                return "Reach the end";
        }

        if(level == 2)
        {
            if(checkpoint < 7)
                return "Find Kittilian";

            if(checkpoint == 7)
                return "Rescue Kittilian";
        }
        
        if(level == 3)
        {
            if(checkpoint < 7)
                return "Liberate the planet";

            if(checkpoint >= 7)
                return "Save Kittilian";
        }

        return "";
    }

    private void RestartGame()
    {
        PlayerPrefs.SetInt("LIVES", 9);

        PlayerPrefs.SetInt("LEVEL", 1);
        PlayerPrefs.SetInt("CHECKPOINT", 0);

        SceneManager.LoadScene("Menu");
    }

    private void NextLevel()
    {
        int nextLevel = PlayerPrefs.GetInt("LEVEL") + 1;
        
        PlayerPrefs.SetInt("LEVEL", nextLevel);
        PlayerPrefs.SetInt("CHECKPOINT", 0);

        SceneManager.LoadScene(nextLevel);
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

        // Get cutscenes
        PlayableDirector[] cutscenes = GameObject.Find("Cutscenes").GetComponentsInChildren<PlayableDirector>();

        // Forwarding all previous cutscenes
        for(int i = 0; i < cutscenes.Length; i++) {
            if(cutscenes[i].transform.position.z <= checkpoints.transform.GetChild(currentCheckpoint).position.z) {
                cutscenes[i].GetComponent<PlayableDirector>().time = cutscenes[i].GetComponent<PlayableDirector>().duration;
                cutscenes[i].GetComponent<PlayableDirector>().Play();

                cutscenes[i].transform.parent.Find("Trigger").gameObject.SetActive(false);
            }
        }

        // Updating objective
        objective.text = GetObjective();

        // Move player into the last checkpoint
        transform.position = checkpoints.transform.GetChild(currentCheckpoint).gameObject.transform.position;

        isPlaying = true;
    }

}

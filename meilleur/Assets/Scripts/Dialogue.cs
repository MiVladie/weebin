using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private Instruction iManager;

    private PlayerController pController;

    private GameObject nextButton;

    private int current = 0;
    
    [Range(0f, 3f)]
    public float startDelay = 0.25f;
    
    [Range(0f, 3f)]
    public float endDelay = 0.35f;

    public bool listenEnding = false;
    public bool disablePlayer = false;

    void Start()
    {
        // Assigning objects
        iManager = transform.parent.GetComponent<Instruction>();
        pController = GameObject.FindObjectOfType<PlayerController>();

        nextButton = transform.GetChild(0).gameObject;

        nextButton.GetComponent<Button>().onClick.AddListener(delegate { onButtonClick(); });
        
        // Hiding content
        setDialogueVisible(false);
    }

    public void Begin()
    {
        // Showing content
        setDialogueVisible(true);

        // Disabling player
        if(disablePlayer)
            pController.enabled = false;

        Play();
    }

    public void onButtonClick()
    {
        if(current == iManager.texts.Length)
        {
            onEnd();
        }
        else
        {
            Play();   
        }
    }

    public void onEnd()
    {
        // Enabling player
        if(disablePlayer)
            pController.enabled = true;

        // Notify gameplay
        if(listenEnding)
            GameObject.FindObjectOfType<Gameplay>().onDialogueEnd(transform.parent.name);

        
        Destroy(transform.parent.gameObject);
    }

    public void Play()
    {
        // Hide next button
        nextButton.SetActive(false);

        // Start reading 
        iManager.Play(current, startDelay, endDelay);
    }
    
    public void onPlayEnd()
    {
        // Checking if the text is last
        if(current == iManager.texts.Length - 1)
        {
            nextButton.transform.GetChild(0).GetComponent<Text>().text = "Okay";
        }

        current++;

        // Show next button
        nextButton.SetActive(true);
    }

    private void setDialogueVisible(bool visible)
    {
        // Image
        transform.parent.GetComponent<Image>().enabled = visible;

        // Button
        transform.GetChild(0).gameObject.SetActive(visible);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    private Instruction iManager;

    private GameObject nextButton;
    private GameObject previousButton;

    private int current = 0;
    private bool isReading = false;

    void Start()
    {
        // Assigning objects
        iManager = transform.parent.GetComponent<Instruction>();

        previousButton = transform.GetChild(0).gameObject;
        nextButton = transform.GetChild(1).gameObject;

        previousButton.GetComponent<Button>().onClick.AddListener(delegate { onPrevious(); });
        nextButton.GetComponent<Button>().onClick.AddListener(delegate { onNext(); });

        // Displaying first text
        iManager.Play(current);

        // Checking there is only one text
        if(iManager.texts.Length < 2)
        {
            previousButton.SetActive(false);
            nextButton.SetActive(false);
        } else
        {
            previousButton.SetActive(false);
        }
    }

    public void onPrevious()
    {
        // Currently reading text
        if(isReading)
            return;

        isReading = true;

        current--;

        // Checking if the text is first
        if(current == 0)
        {
            previousButton.SetActive(false);
        }

        // Enabling next button
        if(!nextButton.activeSelf)
        {
            nextButton.SetActive(true);
        }

        // Start reading 
        iManager.Play(current);
    }

    public void onNext()
    {
        // Currently reading text
        if(isReading)
            return;

        isReading = true;

        current++;

        // Checking if the text is last
        if(current == iManager.texts.Length - 1)
        {
            nextButton.SetActive(false);
        }

        // Enabling previous button
        if(!previousButton.activeSelf)
        {
            previousButton.SetActive(true);
        }

        // Start reading 
        iManager.Play(current);
    }

    public void onPlayEnd()
    {
        isReading = false;
    }

}

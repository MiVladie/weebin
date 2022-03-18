using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject player;
    public GameObject nextButton;

    public string[] texts;

    public float showTextDelay = 3f;
    public float showButtonDelay = 1f;
    public float typeDelay = 0.05f;

    private int currentText = 0;
    private string visibleText = "";

    public bool listenEnding = false;
    public bool disablePlayer = true;

    public void Play()
    {
        setDialogueVisible(true);

        if(disablePlayer) {
            player.GetComponent<PlayerController>().enabled = false;
        }
        
        StartCoroutine(ShowText(showTextDelay));
    }

    public void onNext()
    {
        if(currentText == texts.Length - 1) {
            if(disablePlayer) {
                player.GetComponent<PlayerController>().enabled = true;
            }

            if(listenEnding)
            {
                player.GetComponent<Gameplay>().onDialogueEnd(transform.name);
            }

            Destroy(gameObject);

            return;
        }

        currentText++;

        if(currentText == texts.Length - 1)
        {
            nextButton.transform.GetChild(0).GetComponent<Text>().text = "Okay";
        }

        StartCoroutine(ShowText());
    }

    private void setDialogueVisible(bool visible)
    {
        GetComponent<Image>().enabled = visible;
        transform.GetChild(0).gameObject.SetActive(visible);
    }

    IEnumerator ShowText(float initialDelay = 0)
    {
        transform.GetChild(0).GetComponent<Text>().text = "";
        nextButton.SetActive(false);

        yield return new WaitForSeconds(initialDelay);

        for(int i = 0; i < texts[currentText].Length; i++)
        {
            visibleText = texts[currentText].Substring(0, i);
            transform.GetChild(0).GetComponent<Text>().text = visibleText;

            yield return new WaitForSeconds(typeDelay);
        }

        yield return new WaitForSeconds(showButtonDelay);

        nextButton.SetActive(true);
    }

}

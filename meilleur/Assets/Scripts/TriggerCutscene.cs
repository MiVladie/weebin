using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerCutscene : MonoBehaviour
{
    public GameObject player;

    public PlayableDirector Cutscene;
    public bool disablePlayer = true;

    private bool hasTriggered = false;
    public bool listenEnding = false;

    public void Play()
    {
        if(disablePlayer) {
            StartCoroutine(DeactivatePlayer((float)Cutscene.duration));
        }

        if(listenEnding) {
            StartCoroutine(NotifyGameplay((float)Cutscene.duration));
        }

        Cutscene.Play();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(hasTriggered) {
            return;
        }

        if(other.gameObject.CompareTag("Player"))
        {
            hasTriggered = true;

            Play();
        }
    }

    IEnumerator DeactivatePlayer(float duration) 
    {
        player.GetComponent<PlayerController>().enabled = false;

        yield return new WaitForSeconds(duration);

        player.GetComponent<PlayerController>().enabled = true;
    }

    IEnumerator NotifyGameplay(float duration) 
    {
        yield return new WaitForSeconds(duration); 

        player.GetComponent<Gameplay>().onCutsceneEnd(Cutscene.transform.parent.name);
    }

}

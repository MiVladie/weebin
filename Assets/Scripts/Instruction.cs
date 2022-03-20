using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Instruction : MonoBehaviour
{
    private Text textArea;

    [TextArea]
    public string[] texts;

    [Range(0f, 0.2f)]
    public float typeDelay = 0.05f;

    public UnityEvent onPlayEnd;
    
    void Awake()
    {
        textArea = GameObject.Find("/Instructions/" + transform.name + "/Text").GetComponent<Text>();
    }

    public void Play(int index, float startDelay = 0, float endDelay = 0)
    {
        StartCoroutine(ShowText(index, startDelay, endDelay));
    }

    IEnumerator ShowText(int index, float startDelay = 0, float endDelay = 0)
    {
        textArea.text = "";

        yield return new WaitForSeconds(startDelay);

        for(int i = 0; i <= texts[index].Length; i++)
        {
            textArea.text = texts[index].Substring(0, i);

            yield return new WaitForSeconds(typeDelay);
        }

        yield return new WaitForSeconds(endDelay);

        onPlayEnd.Invoke(); 
    }

}

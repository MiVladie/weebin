using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopController : MonoBehaviour
{
    public string question;

    public string[] options;
    
    public string answer;

    public GameObject popManager;

    public int current;
    public int total;

    public void setPopQuestion(string q, string[] o, string a)
    {
        this.question = q;
        this.options = o;
        this.answer = a;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag != "Player")
            return;
        
        GameObject.FindObjectOfType<PlayerController>().enabled = false;

        this.popManager.transform.GetChild(2).GetComponent<Text>().text = "Question " + current + "/" + total;
        this.popManager.transform.GetChild(2).GetComponent<Text>().color = Color.black;

        this.popManager.transform.GetChild(3).GetComponent<Text>().text = this.question;        
        
        for(int i = 0; i < 3; i++)
        {
            Transform button = this.popManager.transform.GetChild(4).GetChild(i);
            
            button.gameObject.SetActive(true);
            button.GetComponent<Button>().interactable = true;

            string option = this.options[i];

            button.GetChild(0).GetComponent<Text>().text = this.options[i];
            button.GetComponent<Button>().onClick.RemoveAllListeners();
            button.GetComponent<Button>().onClick.AddListener(delegate() { OnOptionHit(option); });
        }

        this.popManager.transform.GetChild(5).gameObject.SetActive(false);
        this.popManager.transform.GetChild(5).GetComponent<Button>().onClick.RemoveAllListeners();
        this.popManager.transform.GetChild(5).GetComponent<Button>().onClick.AddListener(OnAcceptHit);

        this.popManager.SetActive(true);
    }

    public void OnOptionHit(string attempt = "")
    {
        this.popManager.transform.GetChild(2).GetComponent<Text>().text = attempt == this.answer ? "Correct!" : "Incorrect!";
        this.popManager.transform.GetChild(2).GetComponent<Text>().color = attempt == this.answer ? Color.green : Color.red;
        
        for(int i = 0; i < 3; i++)
        {
            Transform button = this.popManager.transform.GetChild(4).GetChild(i);

            if(button.GetChild(0).GetComponent<Text>().text != attempt)
            {
                button.gameObject.SetActive(false);
            }
            else
            {
                button.GetComponent<Button>().interactable = false;
            }
        }

        int answered = PlayerPrefs.GetInt("QUIZZES_ANSWERED") + 1;

        PlayerPrefs.SetInt("QUIZZES_ANSWERED", answered);

        int rank = PlayerPrefs.GetInt("RANK");
        int points = PlayerPrefs.GetInt("POINTS");

        switch(rank)
        {
            case 0:
                if(attempt != this.answer) points -= 50;
                break;
                
            case 1:
                if(attempt != this.answer) points -= 100;
                break;
                
            case 2:
                if(attempt != this.answer) points -= 200;
                break;
                
            default:
                break;
        }

        int newPoints = (int)Mathf.Max(points, 0);

        PlayerPrefs.SetInt("POINTS", newPoints);

        this.popManager.transform.GetChild(5).gameObject.SetActive(true);
    }

    public void OnAcceptHit()
    {
        GameObject.FindObjectOfType<PlayerController>().enabled = true;

        this.transform.parent.gameObject.SetActive(false);

        this.popManager.SetActive(false);
    }
}

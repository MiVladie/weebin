using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsController : MonoBehaviour
{
    public Text score;
    public Image medal;
    public Text material;

    Color32 BRONZE_COLOR = new Color32(224, 121, 0, 255);
    Color32 SILVER_COLOR = new Color32(188, 188, 188, 255);
    Color32 GOLD_COLOR = new Color32(255, 230, 0, 255);

    void Start()
    {
        StartCoroutine(DisplayPoints());
    }

    void UpdateScoreboard()
    {
        int points = PlayerPrefs.GetInt("POINTS");
        int rank = PlayerPrefs.GetInt("RANK");

        int medal = GetMedalFromPoints(points);
        string scoreboard = PlayerPrefs.GetString("SCOREBOARD");

        string item = rank.ToString() + medal.ToString() + points.ToString();

        if(scoreboard == "") {
            PlayerPrefs.SetString("SCOREBOARD", item);
            PlayerPrefs.SetString("LAST_SCORE", item);
            return;
        }

        string newScoreboard = "";

        List<string> scores = scoreboard.Split(" ").ToList();
        bool insertedPoints = false;

        for(int i = 0; i < scores.Count; i++)
        {
            if(i == 5) break;

            int score = int.Parse(scores[i].Substring(2));

            if(score > points || insertedPoints)
            {
                newScoreboard += (i == 0 ? "" : " ") + scores[i];
            }
            else
            {
                newScoreboard += (i == 0 ? "" : " ") + item + " " + scores[i];
                insertedPoints = true;
            }
        }

        if(!insertedPoints)
        {
            newScoreboard += " " + item;
        }

        if(rank != 2)
        {
            string lastScore = PlayerPrefs.GetString("LAST_SCORE");

            if(medal == 2 && lastScore[1] == '2')
            {
                PlayerPrefs.SetInt("RANK", rank + 1);
            }
        }

        PlayerPrefs.SetString("SCOREBOARD", newScoreboard);
        PlayerPrefs.SetString("LAST_SCORE", item);
    }

    IEnumerator DisplayPoints() 
    {
        int points = PlayerPrefs.GetInt("POINTS");
        int medalId = GetMedalFromPoints(points);
        
        switch(medalId)
        {
            case 0:
                material.text = "BRONZE";
                medal.color = BRONZE_COLOR;
                break;
                
            case 1:
                material.text = "SILVER";
                medal.color = SILVER_COLOR;
                break;
                
            case 2:
                material.text = "GOLD";
                medal.color = GOLD_COLOR;
                break;
                
            default:
                break;
        }
        
        UpdateScoreboard();

        yield return new WaitForSeconds(1f); 

        for(int i = 0; i <= points; i++)
        {
            score.text = i.ToString();

            yield return new WaitForSeconds(0.005f); 
        }
        
        yield return new WaitForSeconds(3f); 

        SceneManager.LoadScene("Menu");
    }

    int GetMedalFromPoints(int points)
    {
        int rank = PlayerPrefs.GetInt("RANK");

        switch(rank)
        {
            case 0:
                if(points < 100) return 0;
                if(points < 200) return 1;
                return 2;
                
            case 1:
                if(points < 250) return 0;
                if(points < 400) return 1;
                return 2;

            case 2:
                if(points < 500) return 0;
                if(points < 800) return 1;
                return 2;
                
            default:
                return 0;
        }
    }

}

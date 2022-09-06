using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreboardController : MonoBehaviour
{
    public Transform scoreboardScores;
    public Text currentRank;

    Color32 BRONZE_COLOR = new Color32(224, 121, 0, 255);
    Color32 SILVER_COLOR = new Color32(188, 188, 188, 255);
    Color32 GOLD_COLOR = new Color32(255, 230, 0, 255);

    Color32 BEGINNER_COLOR = new Color32(0, 255, 41, 255);
    Color32 ADVANCED_COLOR = new Color32(0, 106, 255, 255);
    Color32 EXPERT_COLOR = new Color32(255, 91, 0, 255);

    void Start()
    {
        DisplayScore();
        IdentifyRank();
    }

    void DisplayScore()
    {
        string scoreboard = PlayerPrefs.GetString("SCOREBOARD");   

        if(scoreboard == "")
        {
            // Displays: Nothing to see!
            scoreboardScores.GetChild(6).gameObject.SetActive(true);
            return;
        }

        List<string> scores = scoreboard.Split(" ").ToList();

        for(int i = 0; i < scores.Count; i++)
        {
            SetItem(scoreboardScores.GetChild(i), scores[i]);
        }

        string last = PlayerPrefs.GetString("LAST_SCORE");

        if(last != "")
        {
            SetItem(scoreboardScores.GetChild(5), last);
        }
    }

    void SetItem(Transform item, string rawScore)
    {
        string score = rawScore.Substring(2);
        int rank = int.Parse(rawScore[0].ToString());
        int medal = int.Parse(rawScore[1].ToString());

        item.GetChild(1).GetComponent<Text>().text = score;
        item.GetChild(2).GetComponent<Image>().color = medal == 0
            ? BRONZE_COLOR
            : medal == 1
                ? SILVER_COLOR
                : GOLD_COLOR;
                
        item.GetChild(3).GetComponent<Text>().text = rank == 0
            ? "B"
            : rank == 1
                ? "A"
                : "E";

        item.GetChild(3).GetComponent<Text>().color = rank == 0
            ? BEGINNER_COLOR
            : rank == 1
                ? ADVANCED_COLOR
                : EXPERT_COLOR;

        item.gameObject.SetActive(true);
    }

    void IdentifyRank()
    {
        int rank = PlayerPrefs.GetInt("RANK");

        switch(rank)
        {
            case 0:
                currentRank.text = "Beginner";
                currentRank.color = BEGINNER_COLOR;
                break;
                
            case 1:
                currentRank.text = "Advanced";
                currentRank.color = ADVANCED_COLOR;
                break;
                
            case 2:
                currentRank.text = "Expert";
                currentRank.color = EXPERT_COLOR;
                break;

            default:
                break;
        }
    }

    public void AcceptHandler()
    {
        SceneManager.LoadScene("Menu");
    }

}

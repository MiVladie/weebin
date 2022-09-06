using System;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;

    public int HetimiulQuestions = 3;
    public int CisiusQuestions = 3;
    public int JusenoQuestions = 3;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            
            return;
        }

        DontDestroyOnLoad(gameObject);  
    }
    
    public void ApplyQuestions(bool reset = false)
    {
        if(!reset && PlayerPrefs.HasKey("QUIZ_QUESTIONS") && PlayerPrefs.HasKey("QUIZZES_ANSWERED")) 
            return;

        
        int rank = PlayerPrefs.GetInt("RANK");

        string htmlQuestions = "";
        string cssQuestions = "";
        string jsQuestions = "";

        switch(rank)
        {
            case 0:
                htmlQuestions = string.Join("", getUniqueRandomArray(0, PopHetimiul.EASY_QUESTIONS.Length, this.HetimiulQuestions));
                cssQuestions = string.Join("", getUniqueRandomArray(0, PopCisius.EASY_QUESTIONS.Length, this.CisiusQuestions));
                jsQuestions = string.Join("", getUniqueRandomArray(0, PopJuseno.EASY_QUESTIONS.Length, this.JusenoQuestions));
                break;
                
            case 1:
                htmlQuestions = string.Join("", getUniqueRandomArray(0, PopHetimiul.MEDIUM_QUESTIONS.Length, this.HetimiulQuestions));
                cssQuestions = string.Join("", getUniqueRandomArray(0, PopCisius.MEDIUM_QUESTIONS.Length, this.CisiusQuestions));
                jsQuestions = string.Join("", getUniqueRandomArray(0, PopJuseno.MEDIUM_QUESTIONS.Length, this.JusenoQuestions));
                break;
                
            case 2:
                htmlQuestions = string.Join("", getUniqueRandomArray(0, PopHetimiul.HARD_QUESTIONS.Length, this.HetimiulQuestions));
                cssQuestions = string.Join("", getUniqueRandomArray(0, PopCisius.HARD_QUESTIONS.Length, this.CisiusQuestions));
                jsQuestions = string.Join("", getUniqueRandomArray(0, PopJuseno.HARD_QUESTIONS.Length, this.JusenoQuestions));
                break;

            default:
                break;
        }

        string result = "H" + htmlQuestions + "C" + cssQuestions + "J" + jsQuestions;

        PlayerPrefs.SetString("QUIZ_QUESTIONS", result);
        PlayerPrefs.SetInt("QUIZZES_ANSWERED", 0);
    }

    public string GetPlanetQuestion(int planet, int index)
    {
        int rank = PlayerPrefs.GetInt("RANK");

        switch(planet)
        {
            case 1:
                if(rank == 0) return PopHetimiul.EASY_QUESTIONS[index];
                if(rank == 1) return PopHetimiul.MEDIUM_QUESTIONS[index];
                return PopHetimiul.HARD_QUESTIONS[index];
            
            case 2:
                if(rank == 0) return PopCisius.EASY_QUESTIONS[index];
                if(rank == 1) return PopCisius.MEDIUM_QUESTIONS[index];
                return PopCisius.HARD_QUESTIONS[index];
            
            case 3:
                if(rank == 0) return PopJuseno.EASY_QUESTIONS[index];
                if(rank == 1) return PopJuseno.MEDIUM_QUESTIONS[index];
                return PopJuseno.HARD_QUESTIONS[index];

            default:
                return "";
        }
    }

    public string[] GetPlanetOptions(int planet, int index)
    {
        int rank = PlayerPrefs.GetInt("RANK");

        switch(planet)
        {
            case 1:
                if(rank == 0) return getOptionsByIndex(PopHetimiul.EASY_OPTIONS, index);
                if(rank == 1) return getOptionsByIndex(PopHetimiul.MEDIUM_OPTIONS, index);
                return getOptionsByIndex(PopHetimiul.HARD_OPTIONS, index);
            
            case 2:
                if(rank == 0) return getOptionsByIndex(PopCisius.EASY_OPTIONS, index);
                if(rank == 1) return getOptionsByIndex(PopCisius.MEDIUM_OPTIONS, index);
                return getOptionsByIndex(PopCisius.HARD_OPTIONS, index);
            
            case 3:
                if(rank == 0) return getOptionsByIndex(PopJuseno.EASY_OPTIONS, index);
                if(rank == 1) return getOptionsByIndex(PopJuseno.MEDIUM_OPTIONS, index);
                return getOptionsByIndex(PopJuseno.HARD_OPTIONS, index);

            default:
                return new string[] {};
        }
    }

    public string GetPlanetAnswer(int planet, int index)
    {
        int rank = PlayerPrefs.GetInt("RANK");

        switch(planet)
        {
            case 1:
                if(rank == 0) return PopHetimiul.EASY_ANSWERS[index];
                if(rank == 1) return PopHetimiul.MEDIUM_ANSWERS[index];
                return PopHetimiul.HARD_ANSWERS[index];
            
            case 2:
                if(rank == 0) return PopCisius.EASY_ANSWERS[index];
                if(rank == 1) return PopCisius.MEDIUM_ANSWERS[index];
                return PopCisius.HARD_ANSWERS[index];
            
            case 3:
                if(rank == 0) return PopJuseno.EASY_ANSWERS[index];
                if(rank == 1) return PopJuseno.MEDIUM_ANSWERS[index];
                return PopJuseno.HARD_ANSWERS[index];

            default:
                return "";
        }
    }

    public static int[] getUniqueRandomArray(int min, int max, int count) {
        int[] result = new int[count];

        List<int> numbersInOrder = new List<int>();

        for (var x = min; x < max; x++) {
            numbersInOrder.Add(x);
        }

        for (var x = 0; x < count; x++) {
            var randomIndex = UnityEngine.Random.Range(0, numbersInOrder.Count);
            result[x] = numbersInOrder[randomIndex];
            numbersInOrder.RemoveAt(randomIndex);
        }

        return result;
    }

    private string[] getOptionsByIndex(string[,] options, int index)
    {
        return new string[] {
            options[index, 0],
            options[index, 1],
            options[index, 2]
        };
    }

}

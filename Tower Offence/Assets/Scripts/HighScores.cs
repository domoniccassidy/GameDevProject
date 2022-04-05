using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
   
    public Text levelSelectText;
    public Text scoreSelectText;
    public Text[] scoreTexts;
    public Text[] nameTexts;
    int levelIndex;
    int scoreIndex;

    public List<string> leaderboard = new List<string>();


    List<string> levels = new List<string> { "Friendly Flowers","Vicious Volcano" };
    List<string> scores = new List<string> { "Time Taken", "Money Stolen" };




    private void Start()
    {


       

        leaderboard.Add(PlayerPrefs.GetString("Friendly Flowers", "SidTheFist:100,Merlin:110,Karen:120,Domonic:125,Elanco:130-SidTheFist:50000,Merlin:40000,Karen:35000,Domonic:25000,Elanco:20000"));
        leaderboard.Add(PlayerPrefs.GetString("Vicious Volcano", "SidTheFist:110,Merlin:120,Karen:130,Domonic:135,Elanco:140-SidTheFist:60000,Merlin:50000,Karen:45000,Domonic:35000,Elanco:30000"));
        ChangeLevel();
        ChangeScore();
        ChangeText();
    }

    // Update is called once per frame
    public void RightLevelButton()
    {
        if (levelIndex == levels.Count - 1)
        {
            levelIndex = 0;
        }
        else levelIndex++;
        ChangeLevel();
        ChangeText();
    }
    public void LeftLevelButton()
    {
        if (levelIndex == 0)
        {
            levelIndex = levels.Count -1;
        }
        else levelIndex--;
        ChangeLevel();
        ChangeText();
    }
    public void RightScoreButton()
    {
        if (scoreIndex == scores.Count - 1)
        {
            scoreIndex = 0;
        }
        else scoreIndex++;
        ChangeScore();
        ChangeText();
    }
    public void LeftScoreButton()
    {
        if (scoreIndex == 0)
        {
            scoreIndex = scores.Count - 1;
        }
        else scoreIndex--;
        ChangeScore();
        ChangeText();
    }


    void ChangeLevel()
    {
        levelSelectText.text = levels[levelIndex];
        

    }
    void ChangeScore()
    {
        scoreSelectText.text = scores[scoreIndex];
    }
    void ChangeText()
    {
        string levelString = leaderboard[levelIndex].Split('-')[scoreIndex];
   
        string[] seperateString;
       for(int i = 0; i < (seperateString = levelString.Split(',')).Length; i++)
        {
            string[] seperateEntry = seperateString[i].Split(':');
          
            nameTexts[i].text = seperateEntry[0];
            scoreTexts[i].text = seperateEntry[1];        }
    }

}

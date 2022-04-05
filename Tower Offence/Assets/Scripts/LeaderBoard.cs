using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    private static LeaderBoard instance;
    public List<string> leaderboard;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        leaderboard = GameObject.Find("HighScoreManager").GetComponent<HighScores>().leaderboard;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

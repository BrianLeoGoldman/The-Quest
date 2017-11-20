using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

    GameObject player;
    public int score;
    int maxScore;
    private GUIStyle guiStyle = new GUIStyle();
    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        score = 0;
        maxScore = PlayerPrefs.GetInt("MaxScore1", 0);
    }

    void OnGUI()
    {
        guiStyle.fontSize = 30;
        GUI.Label(new Rect(950, 60, 50, 20), " X " + score, guiStyle);
        GUI.Label(new Rect(780, 17, 50, 20), "MAX SCORE: " + maxScore, guiStyle);

    }

    void Update()
    {
        score = player.GetComponent<PlayerManager>().returnScore();
        CheckMaxScoreAndCoins();
    }

    public void CheckMaxScoreAndCoins()
    {
        if (score > maxScore)
        {
            Debug.Log("Saving score...");
            PlayerPrefs.SetInt("MaxScore1", score);
        }
    }
}

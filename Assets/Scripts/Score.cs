using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private static int _score;

    private static void getScore()
    {
        _score = Judge.score;
    }

    void Update()
    {
        getScore();
        scoreText.text = "SCORE: " + _score;
    }
}

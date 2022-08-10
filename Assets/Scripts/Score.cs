using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Judge judge;
    public Text scoreText;
    
    void Update()
    {
        scoreText.text = "SCORE: " + judge.score;
    }
}

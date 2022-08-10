using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLoad : MonoBehaviour
{
    [SerializeField] private Text _score;
    [SerializeField] private Text _clear;
    private static int _loadScore;
    private static int _counter = 1;
    void Start()
    {
        _loadScore = Judge.score;
        _score.text = "Score: " + _loadScore;
        if (_counter == 1)
        {
            _clear.text = (_loadScore >= 432 * 5000 ? "Success!!" : "Faled...");
            // if (_loadScore >= 432 * 5000) _clear.text = "Clear!!";
            // else _clear.text = "False!!";
        }
        else if (_counter == 2)
        {
            _clear.text = (_loadScore >= 341 * 5000 ? "Success!!" : "Faled...");
        }
        else if (_counter == 3)
        {
            _clear.text = (_loadScore >= 302 * 5000 ? "Success!!" : "Faled...");
        }

        _counter++;
    }

}

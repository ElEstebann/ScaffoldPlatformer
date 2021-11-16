using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text playerScore;
    public int currentScore = 0;

    void Update()
    {
        playerScore.text = ("Score: " + currentScore.ToString()); 
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("score", currentScore);
    }

    private void OnEnable()
    {
        currentScore = PlayerPrefs.GetInt("score");
    }
}

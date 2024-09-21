using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;
    public TextMeshProUGUI player3;
    public TextMeshProUGUI player4;
    private int P1Score;
    private int P2Score;
    private int P3Score;
    private int P4Score;
    public GameManager gameManager;
    public void Start()
    {
        P1Score = 0;
        P2Score = 0;
        P3Score = 0;
        P4Score = 0;
        UpdateScoreP1(0);
        UpdateScoreP2(0);
        UpdateScoreP3(0);
        UpdateScoreP4(0);
    }
    public void Update()
    {

    }
    public void UpdateScoreP1(int scoreToAdd)
    {
        P1Score += scoreToAdd;
        player1.text = "" + P1Score;
    }
    public void UpdateScoreP2(int scoreToAdd)
    {
        P2Score += scoreToAdd;
        player2.text = "" + P2Score;
    }
    public void UpdateScoreP3(int scoreToAdd)
    {
        P3Score += scoreToAdd;
        player3.text = "" + P2Score;
    }
    public void UpdateScoreP4(int scoreToAdd)
    {
        P4Score += scoreToAdd;
        player4.text = "" + P2Score;
    }
}

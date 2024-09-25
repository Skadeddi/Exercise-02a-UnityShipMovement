using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scorekeeper : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreboard, timer;
    public void addScore(int score)
    {
        this.score += score;
        scoreboard.text = "Score: " + this.score;
    }

    private void FixedUpdate()
    {
        timer.text = "Time: " + Time.realtimeSinceStartup;
    }
}

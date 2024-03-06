using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerAndHugs : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI hugsTotalScore;
    [SerializeField] GameObject Player;
    [SerializeField] int HowManyFriends = 1;
    [SerializeField] int levelNumber = 1;
    [SerializeField] int TimeInLevel = 60;
    [SerializeField] Canvas EndStats;
    [SerializeField] Scene nextLevel;
    HugScript hugs;
    float timeDown;
    public bool outofTime;
    private void Start()
    {
        hugs = Player.GetComponent<HugScript>();
        timerText.text = "Time Left: " + TimeInLevel;
        timeDown = TimeInLevel;
        EndStats.enabled = false;
    }
    private void Update()
    {
        timeDown -= Time.deltaTime;
        timerText.text = "Time Left: " + timeDown;
        if (timeDown <= 0 || hugs.hugCount >= HowManyFriends)
        {
            hugsTotalScore.text = "You Hugged: " + hugs.hugCount + " out of " + HowManyFriends;
            EndStats.enabled = true;
            outofTime = true;
        }
    }
    public void NextLevel()
    {
        WhatLevelIsNext();
    }
    void WhatLevelIsNext()
    {
        if(levelNumber == 1)
        {
            Debug.Log("1");
            SceneManager.LoadScene("Level 2");
        }
        else if(levelNumber == 2)
        {
            Debug.Log("2");
            SceneManager.LoadScene("Level 3");
        }
        else if(levelNumber == 3)
        {
            Debug.Log("3");
            SceneManager.LoadScene("Win Scene");
        }
    }
}

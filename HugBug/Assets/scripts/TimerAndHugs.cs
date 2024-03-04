using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerAndHugs : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] int TimeInLevel = 60;
    [SerializeField] Canvas EndLevel;
    float timeDown;
    public bool outofTime;
    private void Start()
    {
        timeDown = TimeInLevel;
        EndLevel.enabled = false;
    }
    private void Update()
    {
        timeDown -= Time.deltaTime;
        timerText.text = "Time Left: " + timeDown;
        if (timeDown <= 0)
        {
            EndLevel.enabled = true;
            outofTime = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorialscript : MonoBehaviour
{
    [SerializeField] Canvas tutorialcanvas;
    [SerializeField] TextMeshProUGUI tutorialText;
    [SerializeField] int timeUntildissapear = 3;
    float timer;
    bool didThisPart;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeUntildissapear && didThisPart == false)
        {
            timer = 0;
            didThisPart = true;
            tutorialText.text = "Make sure you hug as many as possible before time runs out! good luck";
        }
        if(timer >= timeUntildissapear && didThisPart == true)
        {
            tutorialcanvas.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorialscript : MonoBehaviour
{
    [SerializeField] Canvas tutorialcanvas;
    [SerializeField] TextMeshProUGUI tutorialText;
    [SerializeField] int timeUntildissapear;
    float timer;
    bool didThisPart;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeUntildissapear && didThisPart == false)
        {
            tutorialText.text = "Make sure you hug as many as possible before time runs out! good luck";
        }
        if(timer >= timeUntildissapear && didThisPart == true)
        {
            tutorialcanvas.enabled = false;
        }
    }
}

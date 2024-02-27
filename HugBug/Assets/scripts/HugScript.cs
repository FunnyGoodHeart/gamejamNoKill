using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class HugScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hugCounterText;

    [SerializeField]  int hugCount = 0;
    GameObject nearbyFriend;
    bool CloseEnough = false;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision Enter");
        if(gameObject.gameObject.tag == "Friend")
        {
            //nearbyFriend = collision.gameObject;
            CloseEnough = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit");
        if (collision.gameObject.tag == "Friend")
        {
            CloseEnough = false;
        }
    }
    void OnHug()
    {
        Debug.Log("Hug");
        if (CloseEnough == true)
        {
            Debug.Log("Hug pt.2");
            hugCount++;
            hugCounterText.text = "Hugs Given: " + hugCount;
        }
    }
}

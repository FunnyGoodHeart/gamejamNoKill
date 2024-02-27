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
    FriendHugLimit friendsPart;
    bool CloseEnough = false;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("FRIEND!");
        if (collision.gameObject.tag == "Friend")
        {
            nearbyFriend = collision.gameObject;
            friendsPart = nearbyFriend.GetComponent<FriendHugLimit>();
            CloseEnough = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(":'(");
        if (collision.gameObject.tag == "Friend")
        {
            CloseEnough = false;
        }
    }
    void OnHug()
    {
        Debug.Log("Hug?");
        if (CloseEnough == true && friendsPart.beenHugged == false)
        {
            Debug.Log("Hug!");
            hugCount++;
            friendsPart.beenHugged = true;
            hugCounterText.text = "Hugs Given: " + hugCount;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class HugScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hugCounterText;

    [SerializeField]  int hugCount = 0;
    GameObject nearbyPerson;
    FriendHugLimit personsPart;
    bool CloseEnough = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("FRIEND?");
        if (collision.gameObject.tag == "Friend" || collision.gameObject.tag == "NonFriend")
        {
            nearbyPerson = collision.gameObject;
            personsPart = nearbyPerson.GetComponent<FriendHugLimit>();
            CloseEnough = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(":'(");
        if (collision.gameObject.tag == "Friend" || collision.gameObject.tag == "NonFriend")
        {
            CloseEnough = false;
        }
    }
    void OnHug()
    {
        Debug.Log("Hug?");
        if(CloseEnough == true)
        {
            if (personsPart.beenHugged == false && personsPart.Friend == true)
            {
                Debug.Log("Hug!");
                hugCount++;
                personsPart.beenHugged = true;
                hugCounterText.text = "Hugs Given: " + hugCount;
            }
            else if (personsPart.NonFriend == true)
            {
                Debug.Log("No Hug ;-;");
                personsPart.attemptAtHug = true;
            }
        }
    }
}

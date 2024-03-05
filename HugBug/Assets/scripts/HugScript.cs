using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class HugScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hugCounterText;
    public int hugCount = 0;
    [SerializeField] float hugCoolDown = 1.5f;
    Animator ani;
    float hugCoolDownTimer;
    bool onCoolDown;
    bool coolDownJustStart = true;
    public int howLongSad = 3;
    public bool Crying;
    public bool huggingAni = false;
    float hugTime = 1;
    float timer;
    GameObject nearbyPerson;
    FriendHugLimit personsPart;
    bool CloseEnough = false;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        hugCoolDownTimer += Time.deltaTime;
        timer += Time.deltaTime;
        if(onCoolDown == true && coolDownJustStart == true)
        {
            hugCoolDownTimer = 0;
            coolDownJustStart = false;
        }
        else if (onCoolDown == true && coolDownJustStart == false && hugCoolDownTimer >= hugCoolDown)
        {
            onCoolDown = false;
            coolDownJustStart = true;
        }
        if (huggingAni == true && timer >= hugTime)
        {
            timer = 0;
            ani.SetBool("hugging", false);
            huggingAni = false;
        }

    }
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
        if (CloseEnough == true && onCoolDown == false)
        {
            if (personsPart.Friend == true && personsPart.beenHugged == false)
            {
                Debug.Log("Hug!");
                ani.SetBool("hugging", true);
                hugCount++;
                personsPart.beenHugged = true;
                hugCounterText.text = "Hugs Given: " + hugCount;
                onCoolDown = true;
                huggingAni = true;
                CloseEnough = false;
                timer = 0;
            }
            
            else if (personsPart.NonFriend == true && personsPart.justBeenHugged == false)
            {
                Debug.Log("No Hug ;-;");
                Crying = true;
                personsPart.attemptAtHug = true;
                onCoolDown = true;
            }
            else
            {
                Debug.Log("no one to give hugs to");
            }
        }
    }
}

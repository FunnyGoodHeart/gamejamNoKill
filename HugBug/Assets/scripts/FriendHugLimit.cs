using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendHugLimit : MonoBehaviour
{
    //this is used for both friends and non friends only scipt name was not changed
    [Header("is Friend?")]
    public bool Friend;
    public bool NonFriend;
    
    [Header("Main Settings")]
    [SerializeField] GameObject player;
    [SerializeField] float timeUntilStartFade;
    [SerializeField] float betweenfade = .3f;

    [Header("Friend Settings")]
    [SerializeField] int napUntilRelocated = 10;
    [SerializeField] int distroyGameObject = 5;
    public bool beenHugged = false;

    [Header("NonFriend Settings")]
    [SerializeField] int nonFriendHugCoolDown = 4;
    public bool attemptAtHug = false;
    public bool justBeenHugged = false;
    //bools
    bool fadingAway;
    bool takingNap = false;
    bool beenTakenAway = false;
    //numbers
    float Timer;
    float fadeTimer;
    int fadeCounter;

    //components
    HugScript hugs;
    Animator ani;
    Rigidbody2D rb;
    PolygonCollider2D pc;
    CircleCollider2D cc;
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();
        cc = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        fadeTimer += Time.deltaTime;
        if (Friend)
        {
            FriendActivites();
        }
        else if (NonFriend)
        {
            NonFriendActivites();
        }
        Dissapear();
    }
    void FriendActivites()
    {
        if (beenHugged == true && takingNap == false) //charatcer hugs
        {
            Debug.Log("ZZZZZZ");
            sr.color = new Color(1f, 1f, 1f, 0f);
            pc.enabled = false;
            cc.enabled = false;
            Timer = 0;
            rb.mass = 100;
            pc.enabled = false;
            takingNap = true;
        }
        if (takingNap == true && Timer >= napUntilRelocated && beenTakenAway == false) //laying down
        {
            Debug.Log("'Relocate'");
            sr.color = new Color(1f, 1f, 1f, 1f);
            ani.SetTrigger("TakeNap");
            fadingAway = true;
            Timer = 0;
            beenTakenAway = true;
        }
        if (beenTakenAway == true && Timer >= distroyGameObject) //gets removed
        {
            Debug.Log("bye bye");
            Destroy(gameObject);
        }
    }
    void NonFriendActivites()
    {
        if(attemptAtHug == true && justBeenHugged == false)
        {
            Debug.Log("NO");
            ani.SetTrigger("AtemptedHug");
            Timer = 0;
            justBeenHugged = true;
        }
        if (Timer >= nonFriendHugCoolDown && justBeenHugged == true)
        {
            attemptAtHug = false;
            justBeenHugged = false;
            Timer = 0;
        }
    }
    void Dissapear()
    {
        if (fadingAway) //disapears after being hugged
        {
            if (fadeCounter == 0 && fadeTimer >= betweenfade)
            {
                fadeCounter++;
                fadeTimer = 0;
            }
            else if(fadeCounter == 1 && fadeTimer >= betweenfade)
            {
                sr.color = new Color(1f, 1f, 1f, .75f);
                fadeCounter += 1;
                fadeTimer = 0;
            }
            else if(fadeCounter == 2 && fadeTimer >= betweenfade)
            {
                sr.color = new Color(1f, 1f, 1f, .5f);
                fadeCounter += 1;
                fadeTimer = 0;
            }
            else if(fadeCounter == 3 && fadeTimer >= betweenfade)
            {
                sr.color = new Color(1f, 1f, 1f, .25f);
                fadeCounter += 1;
                fadeTimer = 0;
            }
            else if (fadeCounter == 4 && fadeTimer >= betweenfade)
            {
                sr.color = new Color(1f, 1f, 1f, .0f);
                fadeCounter += 1;
                fadeTimer = 0;
            }
        }
    }
}

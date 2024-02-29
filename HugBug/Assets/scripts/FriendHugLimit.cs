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
    [SerializeField] GameObject childCollision;
    [SerializeField] float betweenfade = .3f;
    [Header("Friend Settings")]
    [SerializeField] int napUntilRelocated = 10;
    [SerializeField] int distroyGameObject = 5;
    public bool beenHugged = false;
    [Header("NonFriend Settings")]
    public bool attemptAtHug = false;

    Animator ani;
    bool takingNap = false;
    bool beenTakenAway = false;
    HugScript hugs;
    float Timer;
    Rigidbody2D rb;
    CapsuleCollider2D cc;
    CapsuleCollider2D childcc;
    BoxCollider2D takeAwayBox;
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        takeAwayBox = GetComponent<BoxCollider2D>();
        takeAwayBox.enabled = false;
        childcc = childCollision.GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Friend)
        {
            FriendActivites();
        }
        else if (NonFriend)
        {
            NonFriendActivites();
        }
    }
    void FriendActivites()
    {
        if (beenHugged == true && takingNap == false) //starts taking nap
        {
            Debug.Log("ZZZZZZ");
            ani.SetTrigger("TakeNap");
            Timer = 0;
            rb.mass = 100;
            cc.enabled = false;
            takingNap = true;
        }
        if (takingNap == true && Timer >= napUntilRelocated && beenTakenAway == false) //removes character from being seen
        {
            Debug.Log("'Relocate'");
            ani.SetTrigger("isRelocate");
            childcc.enabled = false;
            takeAwayBox.enabled = true;
            Timer = 0;
            beenTakenAway = true;
        }
        if (beenTakenAway == true && Timer >= distroyGameObject) //removes game object by "relocating it"
        {
            Debug.Log("bye bye");
            Destroy(gameObject);
        }
    }
    void NonFriendActivites()
    {
        if(attemptAtHug == true)
        {
            Debug.Log("NO");
            ani.SetTrigger("AtemptedHug");
            Timer = 0;
        }
        
    }
}

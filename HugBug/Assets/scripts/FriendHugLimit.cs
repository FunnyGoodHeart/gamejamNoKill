using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendHugLimit : MonoBehaviour
{
    [SerializeField] GameObject player;
    public bool beenHugged = false;

    HugScript hugs;
    void Start()
    {
        
    }

    void Update()
    {
        if (beenHugged == true)
        {
            Destroy(gameObject);
        }
    }
}

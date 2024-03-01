using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement: MonoBehaviour
{
    HugScript hugs;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5.0f;
    Animator ani;
    float cryTimer;
    Vector2 moveInput;
    bool firstTear = true;
    // Start is called before the first frame update
    void Start()
    {
        hugs = GetComponent<HugScript>();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cryTimer += Time.deltaTime;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        ani.SetFloat("Horizontal", moveInput.x);
        ani.SetFloat("Vertical", moveInput.y);
        ani.SetFloat("Speed", moveInput.magnitude);
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        rb.velocity = playerVelocity;
        if(hugs.Crying == true)
        {
            IsCrying();
        }
    }
    void OnMove(InputValue value)
    {
        if(hugs.Crying == false)
        {
            moveInput = value.Get<Vector2>();
        }
        
    }
    void IsCrying()
    {
        ani.SetBool("isCrying", true);
        if (firstTear == true)
        {
            Debug.Log("sniff sniff");
            cryTimer = 0;
            firstTear = false;
        }
        if (cryTimer >= hugs.howLongSad)
        {
            Debug.Log("WHAAAAA");
            ani.SetBool("isCrying", false);
            hugs.Crying = false;
            cryTimer = 0;
        }
    }
}

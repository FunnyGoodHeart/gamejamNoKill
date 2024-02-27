using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement: MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float moveSpeed = 5.0f;
    Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //vec3 = new Vector2(x, y) * moveSpeed; // * Time.deltaTime * 60;
        //rb.velocity = vec3.normalized;
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        rb.velocity = playerVelocity;
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}

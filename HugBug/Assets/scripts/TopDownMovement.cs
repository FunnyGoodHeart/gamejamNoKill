using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class TopDownMovement: MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float moveSpeed = 5.0f;
    Vector2 vec2;
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

        vec2 = new Vector2(x, y) *( moveSpeed * Time.deltaTime * 60);
        rb.velocity = vec2.normalized;
    }
}

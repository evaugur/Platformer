using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float runSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    private Rigidbody2D rb;
    private Vector3 startPosition;
    private Vector3 direction;
    private float jumpCounter = 1;

    private void Jump()
    {
      if (Input.GetKeyDown(KeyCode.Space) && jumpCounter == 1)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCounter = 0;
        }
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        transform.Translate(moveInput * Vector2.right * runSpeed * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCounter = 1;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        jumpCounter = 0;
    }
}

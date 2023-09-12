using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 input;
    public float speed;
    //[SerializeField] private FMODUnity.StudioEventEmitter audioEmitter;

    public bool isGrounded;
    public float jumpForce;

    private void Move(Vector2 input)
    {
        this.input = input;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(input.x, input.y);
        rb.position += velocity*Time.fixedDeltaTime * speed;
    }

    private void OnEnable()
    {
        InputManager.OnPlayerMovement += Move;
        InputManager.OnJump += Jump;
    }
   
    private void OnDisable()
    {
        InputManager.OnPlayerMovement -= Move;
        InputManager.OnJump -= Jump;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }

}

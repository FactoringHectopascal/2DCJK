using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class PlatformerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1.0f;
    [SerializeField]
    float jumpSpeed = 2.0f;
    Rigidbody2D rb;
    bool grounded = false;
    [SerializeField]
    float rollingMax = 5f;
    public float rolling = 0f;
    [SerializeField]
    float coolDown = 0f;
    [SerializeField]
    float coolDownMax = 1.5f;
    [SerializeField]
    int dashSpeed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rolling > 0f)
        {
            rolling -= Time.deltaTime;
        }
        else
        {

        // left and right movement based on horizontal axis input
        float moveX = UnityEngine.Input.GetAxisRaw("Horizontal");
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * moveSpeed; 
        rb.velocity = velocity;
        // jump when we hit spacebar 
        if (UnityEngine.Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            grounded = false;
        }
        if (UnityEngine.Input.GetKey(KeyCode.LeftShift) && grounded && coolDown <= 0 && moveX != 0)
        {
         rb.velocity.Normalize();
         rb.velocity += new Vector2(moveX * dashSpeed, velocity.y * dashSpeed);
         coolDown = coolDownMax;
         rolling = rollingMax;
        }
        else
        {
            coolDown -= Time.deltaTime;
        }

        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }
    }
}
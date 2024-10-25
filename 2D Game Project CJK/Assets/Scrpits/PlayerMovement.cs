using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;
    [SerializeField]
    float runSpeed = 12f;
    [SerializeField]
    float rollingMax = 5f;
    public float rolling = 0f;
    //float rollingRotation = 0;
    //float rollingIncrement = 3;
    float coolDown = 0f;
    float coolDownMax = 1.5f;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "speedboost")
        {
            runSpeed += .5f;
            moveSpeed += 1f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (rolling > 0f)
        {
            rolling -= Time.deltaTime; //countdown timer
           // rollingRotation += rollingIncrement; //adding increment to rotation
           // rollingRotation %= 360; // capping the rotation at 360 degrees
           // GetComponent<Rigidbody2D>().transform.Rotate(new Vector3(0, rollingRotation,0), Space.Self);
            //rollingIncrement -= 0.1f;
        }
        else
        {
            //check for horizontal and vvertical input
            //move the player based on that input.
            float xInput = Input.GetAxis("Horizontal");
            float yInput = Input.GetAxis("Vertical");
            //Velocity is a Vector2 variable, which stores 
            //two floats, x and y.
            GetComponent<Rigidbody2D>().velocity = new Vector2(xInput, yInput) * moveSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(xInput, yInput) * runSpeed;
            }
            if (coolDown <= 0f) // if cooldown is less than or equal to zero
            {
                if (Input.GetKey(KeyCode.F))
                {
                    GetComponent<Rigidbody2D>().velocity += new Vector2(xInput * 5f, yInput * 5f);
                    rolling = rollingMax;
                    coolDown = coolDownMax; //add a cooldown
                }

            }
            else
            {
                coolDown -= Time.deltaTime; //if there is a countdown, count it down.
            }

        }
      
     }
}

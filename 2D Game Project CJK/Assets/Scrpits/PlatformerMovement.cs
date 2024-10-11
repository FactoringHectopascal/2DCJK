using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1.0f;
    [SerializeField]
    float jumpSpeed = 2.0f;
    public Rigidbody2D rb;
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

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rolling > 0f) // if a player is dodging
        {
            rolling -= Time.deltaTime; // count down the dodging timer
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
            
            if (UnityEngine.Input.GetKey(KeyCode.LeftShift) && grounded && coolDown <= 0 && moveX != 0 && Mathf.Abs(velocity.y) <= 0.01f) // if you're moving, grounded, not jumping, have no cooldown, and press LShift
            {
                rb.velocity.Normalize();
                rb.velocity += new Vector2(moveX * dashSpeed, velocity.y * dashSpeed); // add to the players velocity with the value "dashSpeed" 
                coolDown = coolDownMax; // reset the timer
                rolling = rollingMax; // start dodge timer (so that a player doesn't dodge infinitely)
            }
            else
            {
                coolDown -= Time.deltaTime;
            }
        }
        int x = (int)UnityEngine.Input.GetAxisRaw("Horizontal");
        if (x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        else if (x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
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

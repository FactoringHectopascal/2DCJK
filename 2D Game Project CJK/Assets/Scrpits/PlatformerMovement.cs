using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    bool jumping;
    GameObject attackCenter;
    Animator anim;
    public int jumpsLeft;
    public int jumpsMax = 1;
    [SerializeField]
    Image dashCooldownBar;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<PlayerCombat>();
        attackCenter = GetComponent<PlayerCombat>().attackCenter;
        GetComponent<PlatformerMovement>();
        anim = GetComponent<Animator>();
        jumpsLeft = jumpsMax;
        Physics2D.IgnoreLayerCollision(7, 8, true);
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
            anim.SetBool("grounded", grounded);
            anim.SetFloat("y", velocity.y);
            int x = (int)Input.GetAxisRaw("Horizontal");
            anim.SetInteger("x", x);
            // jump when we hit spacebar 
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
            {
                Physics2D.IgnoreLayerCollision(7, 8, true);
                jumpsLeft -= 1;
                velocity.y = 0;
                rb.AddForce(new Vector2(0, 90 * jumpSpeed));
                velocity.x = 0;
                grounded = false;
                jumping = true;
                rb.gravityScale = 1.6f;
            }
            if (grounded == true)
            {
                jumpsLeft = jumpsMax;
            }
            if (UnityEngine.Input.GetKey(KeyCode.LeftShift) && jumping && coolDown <= 0 && moveX != 0)
            {
                rb.velocity.Normalize();
                rb.velocity += new Vector2(moveX * dashSpeed, velocity.y); // add to the players velocity with the value "dashSpeed" 
                coolDown = coolDownMax; // reset the timer
                rolling = rollingMax; // start dodge timer (so that a player doesn't dodge infinitely)
            }
            if (UnityEngine.Input.GetKey(KeyCode.LeftShift) && grounded && coolDown <= 0 && moveX != 0 && Mathf.Abs(velocity.y) <= 0.01f) // if you're moving, grounded, not jumping, have no cooldown, and press LShift
            {
                rb.velocity.Normalize();
                rb.velocity += new Vector2(moveX * dashSpeed, velocity.y);
                coolDown = coolDownMax;
                rolling = rollingMax;
            }
            else
            {
   
                coolDown -= Time.deltaTime; // count down the timer
            }
        }
        if (grounded == true)
        {
            rb.gravityScale = 1;
        }
        JumpCheck();
        Flip();
        dashCooldownBar.fillAmount = coolDownMax - coolDown;
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
    private void JumpCheck()
    {
        if (grounded)
        {
            jumping = false;
        }
        if (jumping)
        {
            grounded = false;
        }
    }
    public void Flip()
    {
        int x = (int)Input.GetAxisRaw("Horizontal");
        if (x > 0)
        {
            attackCenter.transform.localPosition = new Vector2(Mathf.Abs(attackCenter.transform.localPosition.x), attackCenter.transform.localPosition.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x < 0)
        {
            attackCenter.transform.localPosition = new Vector2(-Mathf.Abs(attackCenter.transform.localPosition.x), attackCenter.transform.localPosition.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

}

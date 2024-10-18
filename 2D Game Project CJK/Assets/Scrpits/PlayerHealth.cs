using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Build;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField]
    public float health = 10;
    [SerializeField]
    public float maxHealth = 10;
    [SerializeField]
    Image healthBar;
    [SerializeField]
    public TextMeshProUGUI text;
    [Header("Knockback")]
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float knockBack;
    float x;
    bool facingLeft;
    bool facingRight;
    [Header("Iframes")]
    [SerializeField]
    float iFramesDuration;
    [SerializeField]
    int numOfFlashes;
    bool iFrames;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        health = maxHealth;
        text.text = "" + health;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = rb.velocity.x;
        if (x < 0)
        {
            facingLeft = true;
            facingRight = false;
        }
        if (x > 0)
        {
            facingRight = true;
            facingLeft = false;
        }
    }
    public void PlayerTakeDamage()
    {
        if (GetComponent<PlatformerMovement>().rolling > 0f)
        {
            return;
        }
        else if (GetComponent<Parry>().isParrying == true)
        {
            return;
        }
        if (iFrames == true)
        {
            return;
        }
        else
        {
            health -= 1;
            StartCoroutine(Invulnerability());
            text.text = "" + health;
            healthBar.fillAmount = health / maxHealth;
            if (facingLeft)
            {
                rb.AddForce(new Vector2(50 * knockBack, 20 * knockBack));
            }
            else if (facingRight)
            {
                rb.AddForce(new Vector2(-50 * knockBack, 20 * knockBack));
            }
        }
        if (health <= 0)
        {
            Debug.Log("You Died!");
        }
    }
    private IEnumerator Invulnerability()
    {
        iFrames = true;
        for (int i = 0; i < numOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numOfFlashes * 2));
        }
        iFrames = false;
    }
}




using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Build;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    [Header ("Health")]
    public float health = 30;
    [SerializeField]
    public float maxHealth = 30;
    [SerializeField]
    public Image healthBar;
    [SerializeField]
    public TextMeshProUGUI text;
    [Header("Knockback")]
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float knockBack;
    bool facingLeft;
    bool facingRight;
    [Header("Iframes")]
    [SerializeField]
    float iFramesDuration;
    [SerializeField]
    int numOfFlashes;
    bool iFrames;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    GameObject shieldSprite;
    public bool shield;
    public float shieldCooldown = 5f;
    float shieldCurrentCooldown;
    public bool shieldGot;
    void Start()
    {
        health = maxHealth;
        text.text = health + "/" + maxHealth;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        shieldSprite = GameObject.FindGameObjectWithTag("shield");
    }

    // Update is called once per frame
    void Update()
    {
        shieldCurrentCooldown -= Time.deltaTime;
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
        if(health > maxHealth)
        {
            health = maxHealth;
            text.text = health + "/" + maxHealth;
            healthBar.fillAmount = health / maxHealth;
        }
        if(shieldCurrentCooldown <= 0 && shieldGot)
        {
            shield = true;
            shieldSprite.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (shield)
        {
            shieldSprite.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    public void PlayerTakeDamage(float damage)
    {   
        if (GetComponent<PlatformerMovement>().rolling > 0f)
        {
            return;
        }
        else if (shield)
        {
            StartCoroutine(InvulnerabilityShield());
            shieldSprite.GetComponent<SpriteRenderer>().enabled = false;
            shieldCurrentCooldown = shieldCooldown;
            shield = false;
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
            health -= damage;
            StartCoroutine(Invulnerability());
            text.text = health + "/" + maxHealth;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    private IEnumerator InvulnerabilityShield()
    {
        iFrames = true;
        yield return new WaitForSeconds(1);
        iFrames = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
            health += 1;
    }
}




using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public float enemyHealthValue;
    [SerializeField]
    GameObject coin;
    [SerializeField]
    Rigidbody2D eRB;
    [SerializeField]
    float knockBack;
    bool facingLeft;
    bool facingRight;
    EnemyAI enemyAi;
    [SerializeField]
    public Image healthBar;
    public float enemyHealthValueMax;
    [SerializeField]
    bool boss;
    // Start is called before the first frame update
    void Start()
    {
        eRB = GetComponent<Rigidbody2D>();
        enemyAi = GetComponent<EnemyAI>();
        if (boss)
        {
            enemyHealthValue = enemyHealthValueMax;
            return;
        }
        if (enemyAi.eliteEnemy == true)
            enemyHealthValue = Random.Range(60, 95);
        if (enemyAi.normalEnemy == true)
            enemyHealthValue = Random.Range(50, 80);
        enemyHealthValueMax = enemyHealthValue;
    }

    public void Update()
    {
        float x = eRB.velocity.x;
        if (enemyHealthValue <= 0 && enemyAi.eliteEnemy)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
            Instantiate(coin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (enemyHealthValue <= 0)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
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
    public void TakeDamage(float damage)
    {
        enemyHealthValue -= damage;
        healthBar.fillAmount = enemyHealthValue / enemyHealthValueMax;
        if (facingLeft)
        {
            eRB.AddForce(new Vector2(50 * knockBack, 20 * knockBack));
        }
        else if (facingRight)
        {
            eRB.AddForce(new Vector2(-50 * knockBack, 20 * knockBack));
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
            TakeDamage(4);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "throwingKnife")
            TakeDamage(6);
    }
}

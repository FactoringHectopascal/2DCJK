using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public float enemyHealthValue = 20;
    [SerializeField]
    GameObject coin;
    [SerializeField]
    Rigidbody2D eRB;
    [SerializeField]
    float knockBack;
    float x;
    bool facingLeft;
    bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        eRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        float x = eRB.velocity.x;
        if (enemyHealthValue <= 0)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(x < 0)
        {
            facingLeft = true;
            facingRight = false;
        }
        if(x > 0)
        {
            facingRight = true;
            facingLeft = false;
        }
    }
    public void TakeDamage(float damage)
    {
        enemyHealthValue -= damage;
        if (facingLeft)
        {
            eRB.AddForce(new Vector2(50 * knockBack, 20 * knockBack));
        }
        else if (facingRight)
        {
            eRB.AddForce(new Vector2(-50 * knockBack, 20 * knockBack));
        }
    }
}

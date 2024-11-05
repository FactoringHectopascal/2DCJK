using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    Animator swordAnim;
    [SerializeField]
    public GameObject attackCenter;
    [SerializeField]
    public float attackRadius;
    [SerializeField]
    LayerMask enemiesLayer;
    public PlatformerMovement player;
    [SerializeField]
    public float attackRate = 0.5f;
    [SerializeField]
    public float timer;
    [SerializeField]
    GameObject sword;
    public float playerDMG = 5f;
    float knifeTimer = 1.5f;
    float knifeTimerCurrent;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float knifeSpeed;
    float knifeLifetime = 3f;
    private void Start()
    {
        swordAnim = sword.GetComponent<Animator>();
        GetComponent<EnemyHealth>();
        GetComponent<PlatformerMovement>();
    }
    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.R))
            Attack();
        AttackRate();
        if (UnityEngine.Input.GetKeyDown(KeyCode.F) && knifeTimerCurrent <= 0)
            KnifeThrow();
        knifeTimerCurrent -= Time.deltaTime;
    }

    public void KnifeThrow()
    {
        float moveX = UnityEngine.Input.GetAxisRaw("Horizontal");
        int x = (int)Input.GetAxisRaw("Horizontal");
        if (x < 0)
            Mathf.Abs(moveX);
        else if (x > 0)
            Mathf.Abs(-moveX);
        GameObject knife = Instantiate(prefab, transform.position, Quaternion.identity);
        knife.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * knifeSpeed, player.transform.position.y);
        Destroy(knife, knifeLifetime);
        knifeTimerCurrent = knifeTimer;
    }
    public void Attack()
    {
        if (timer > attackRate)
        {
            timer = 0f;
            swordAnim.SetTrigger("attacking");
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackCenter.transform.position, attackRadius, enemiesLayer);
            Debug.Log(enemies.Length);
            foreach (Collider2D enemy in enemies)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(playerDMG);
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackCenter.transform.position, attackRadius);
    }

    private void AttackRate()
    {
        timer += Time.deltaTime;
    }
}
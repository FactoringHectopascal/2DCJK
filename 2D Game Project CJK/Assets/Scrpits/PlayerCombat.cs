using UnityEditor.Tilemaps;
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
    SpriteRenderer swordSpriteRenderer;

    private void Start()
    {
        swordAnim = sword.GetComponent<Animator>();
        GetComponent<EnemyHealth>();
        GetComponent<PlatformerMovement>();
        swordSpriteRenderer = sword.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.R))
        {
            Attack();
        }
        AttackRate();
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
                enemy.GetComponent<EnemyHealth>().TakeDamage();
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
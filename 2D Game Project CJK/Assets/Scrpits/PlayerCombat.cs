using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    public GameObject attackCenter;
    [SerializeField]
    float attackRadius;
    [SerializeField]
    LayerMask enemiesLayer;
    public PlatformerMovement player;


    private void Start()
    {
        animator = GetComponent<Animator>();
        GetComponent<EnemyHealth>();
        GetComponent<PlatformerMovement>();
    }
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.R))
        {
            Attack();
        }
    }

    public void Attack()
    {

        animator.SetTrigger("IsAttacking");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackCenter.transform.position, attackRadius, enemiesLayer);
        Debug.Log(enemies.Length);
        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage();
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackCenter.transform.position, attackRadius);
    }
}
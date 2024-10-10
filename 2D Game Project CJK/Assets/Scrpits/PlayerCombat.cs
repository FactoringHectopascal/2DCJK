using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    GameObject attackCenter;
    [SerializeField]
    float attackRadius;
    [SerializeField]
    LayerMask enemiesLayer;
    [SerializeField]
    float attackRateCurrent = 0f;
    [SerializeField]
    float attackRate = 1;

    private void Start()
    {
       animator = GetComponent<Animator>();
       GetComponent<EnemyHealth>();
    }
    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.R))
        {
            Attack();
        }
        else
        {
            attackRateCurrent -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if(attackRateCurrent == 0f)
        {
        animator.SetTrigger("IsAttacking");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackCenter.transform.position, attackRadius, enemiesLayer);
        foreach(Collider2D enemy in enemies)
        {
            Debug.Log("HitEnemy");
        }
        attackRateCurrent = attackRate;

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackCenter.transform.position, attackRadius);
    }
}
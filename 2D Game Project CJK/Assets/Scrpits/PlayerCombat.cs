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
    LayerMask enemies;

    private void Start()
    {
       animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.R))
        {
            Attack();
        }
    }
    public void AttackEnd()
    {
        animator.SetBool("isAttacking", false);
    }
    public void Attack()
    {
        animator.SetBool("isAttacking", true);
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackCenter.transform.position, attackRadius, enemies);
        foreach(Collider2D enemyObject in enemy)
        {
            Debug.Log("You Hit Someone, monster.");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackCenter.transform.position, attackRadius);
    }
}
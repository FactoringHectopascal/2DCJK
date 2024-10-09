using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    public float attackRange = 5f;
    GameObject attackPoint;
    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.Mouse3))
        {
            LayerMask enemy = LayerMask.GetMask("Enemy");
            Physics2D.OverlapCircle(attackPoint.transform.position, attackRange, enemy);
            
        }
   
    }
}

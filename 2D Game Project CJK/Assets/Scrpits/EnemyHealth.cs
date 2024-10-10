using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public float enemyHealthValue = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void Update()
    {
        if(enemyHealthValue <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage()
    {
        enemyHealthValue -= 20;
    }
}

using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public float enemyHealthValue = 20;
    [SerializeField]
    GameObject coin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (enemyHealthValue <= 0)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void TakeDamage()
    {
        enemyHealthValue -= 5;
    }
}

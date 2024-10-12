using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public float health = 10;
    [SerializeField]
    public float maxHealth = 10;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("You Died!");
        }
    }
    public void PlayerTakeDamage()
    {
        if (GetComponent<PlatformerMovement>().rolling > 0f)
        {
            return;
        }
        else
        {
            health -= 1;
        }
    }
}




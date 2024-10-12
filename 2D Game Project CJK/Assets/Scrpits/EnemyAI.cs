using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float chaseSpeed = 10f;
    [SerializeField]
    float ChaseTriggerDistance = 5.0f;
    [SerializeField]
    bool returnHome = true;
    Vector3 home;
    [SerializeField]
    LayerMask playerLayer;
    [SerializeField]
    public GameObject attackCenter;
    [SerializeField]
    float attackRadius;
    [SerializeField]
    public GameObject playerAttackCenter;
    [SerializeField]
    public float playerAttackRadius;
    [SerializeField]
    Animator anim;
    [SerializeField]
    float coolDown = 0f;
    [SerializeField]
    float coolDownMax = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        home = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if the player gets too close
        Vector3 playerPosition = new Vector2(player.transform.position.x, transform.position.y);
        Vector3 chaseDir = playerPosition - transform.position;
        Vector3 homeDir = home - transform.position;
        if (chaseDir.magnitude < ChaseTriggerDistance)
        {
            //chase the player
            //chase direction = players position - my current position
            //move in the direction of the player
            chaseDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = chaseDir * chaseSpeed;
        }
        else if (returnHome && homeDir.magnitude > 0.2f)
        {
            //return home
            homeDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = homeDir * chaseSpeed;
        }
        else
        {
            //if the player is NOT close, stop moving & we're not trying to return home, stop moving
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        Collider2D[] playerDetection = Physics2D.OverlapCircleAll(attackCenter.transform.position, attackRadius, playerLayer); //adds a detection circle around the enemy
        foreach (Collider2D player in playerDetection) // for every player returned in the playerDetection array (there will only be one)
        {
            EnemyAttack();
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        int x = (int)player.transform.position.x;
        if (x < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if (x > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        coolDown -= Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackCenter.transform.position, attackRadius);
    }
    public void EnemyAttack()
    {
        if (coolDown <= 0)
        {
            anim.SetTrigger("attacking");
            Collider2D[] playerAttackDetection = Physics2D.OverlapCircleAll(playerAttackCenter.transform.position, playerAttackRadius, playerLayer);
            foreach (Collider2D player in playerAttackDetection)
            {
                player.GetComponent<PlayerHealth>().PlayerTakeDamage();
            }
            coolDown = coolDownMax;
        }
    }
}

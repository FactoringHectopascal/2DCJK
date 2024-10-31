using System.Text;
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
    bool grounded;
    Rigidbody2D eRB;
    public bool normalEnemy;
    public bool eliteEnemy;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        home = transform.position;
        Physics2D.IgnoreLayerCollision(7, 7);
        eRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        int num = Random.Range(1, 3);
        if(num == 1)
        {
            eliteEnemy = true;
            normalEnemy = false;
            spriteRenderer.color = Color.blue;
        }
        else if (num == 2)
        {
            eliteEnemy = false;
            normalEnemy = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if the player gets too close
        Vector3 playerPosition = new Vector2(player.transform.position.x, transform.position.y);
        Vector2 chaseDir = playerPosition - transform.position;
        Vector3 homeDir = home - transform.position;
        if (chaseDir.magnitude < ChaseTriggerDistance && grounded == true)
        {
            //chase the player
            //chase direction = players position - my current position
            //move in the direction of the player
            chaseDir.Normalize();
            eRB.velocity = chaseDir * chaseSpeed;
        }
        else if (returnHome && homeDir.magnitude > 0.2f && grounded == true)
        {
            //return home
            homeDir.Normalize();
            eRB.velocity = homeDir * chaseSpeed;
        }
        else
        {
            //if the player is NOT close, stop moving & we're not trying to return home, stop moving
            eRB.velocity = Vector3.zero;
        }
        if(grounded == false)
        {
            eRB.velocity = Vector3.zero;
            eRB.gravityScale = 25f;
        }
        Collider2D[] playerDetection = Physics2D.OverlapCircleAll(attackCenter.transform.position, attackRadius, playerLayer); //adds a detection circle around the enemy
        foreach (Collider2D player in playerDetection)
        {
            anim.SetTrigger("attacking"); // dude
            eRB.velocity = Vector3.zero;
        }

        float turnDir = player.transform.position.x - transform.position.x;
        int x = (int)turnDir;
        if (x < 0)
        {
            playerAttackCenter.transform.localPosition = new Vector2(-Mathf.Abs(playerAttackCenter.transform.localPosition.x), playerAttackCenter.transform.localPosition.y);
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (x > 0)
        {
            playerAttackCenter.transform.localPosition = new Vector2(Mathf.Abs(playerAttackCenter.transform.localPosition.x), playerAttackCenter.transform.localPosition.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        coolDown -= Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackCenter.transform.position, attackRadius);
        Gizmos.DrawWireSphere(playerAttackCenter.transform.position, playerAttackRadius);
    }
    public void EnemyAttack()
    {
        if (coolDown <= 0 && normalEnemy)
        {
            Collider2D[] playerAttackDetection = Physics2D.OverlapCircleAll(playerAttackCenter.transform.position, playerAttackRadius, playerLayer);
            foreach (Collider2D player in playerAttackDetection)
            {
                player.GetComponent<PlayerHealth>().PlayerTakeDamage(3);
            }
            coolDown = coolDownMax;
        }
        if(coolDown <= 0 && eliteEnemy)
        {
            anim.SetTrigger("attacking");
            Collider2D[] playerAttackDetection = Physics2D.OverlapCircleAll(playerAttackCenter.transform.position, playerAttackRadius, playerLayer);
            foreach (Collider2D player in playerAttackDetection)
            {
                player.GetComponent<PlayerHealth>().PlayerTakeDamage(6);
            }
            coolDown = coolDownMax;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }
    }
}

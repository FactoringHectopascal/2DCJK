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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        home = transform.position;
        Physics2D.IgnoreLayerCollision(7, 7);
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
            GetComponent<Rigidbody2D>().velocity = chaseDir * chaseSpeed;
        }
        else if (returnHome && homeDir.magnitude > 0.2f && grounded == true)
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
        if(grounded == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().gravityScale = 25f;
        }
        Collider2D[] playerDetection = Physics2D.OverlapCircleAll(attackCenter.transform.position, attackRadius, playerLayer); //adds a detection circle around the enemy
        foreach (Collider2D player in playerDetection)
        {
            EnemyAttack();
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

        float turnDir = player.transform.position.x - transform.position.x;
        int x = (int)turnDir;
        if (x < 0)
        {
            playerAttackCenter.transform.localPosition = new Vector2(-Mathf.Abs(playerAttackCenter.transform.localPosition.x), playerAttackCenter.transform.localPosition.y);
            GetComponent<SpriteRenderer>().flipX = false;

        }
        else if (x > 0)
        {
            playerAttackCenter.transform.localPosition = new Vector2(Mathf.Abs(playerAttackCenter.transform.localPosition.x), playerAttackCenter.transform.localPosition.y);
            GetComponent<SpriteRenderer>().flipX = true;
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

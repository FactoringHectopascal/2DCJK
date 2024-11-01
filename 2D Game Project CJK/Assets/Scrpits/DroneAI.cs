using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAI : MonoBehaviour
{
    [SerializeField]
    float timer = 0;
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    float shootDelay = 0.5f;
    [SerializeField]
    float shootRange = 5f;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float shootSpeed = 10f;
    [SerializeField]
    float bulletLifetime = 2.0f;
    GameObject player;
    Rigidbody2D rb;
    [SerializeField]
    float chaseSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y + 1.6f);
        Vector2 chaseDir = playerPosition - transform.position;
        chaseDir.Normalize();
        rb.velocity = chaseDir * chaseSpeed;
        int x = (int)Input.GetAxisRaw("Horizontal");
        if (x < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else if (x > 0)
            GetComponent<SpriteRenderer>().flipX = false;
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 1)
            return;
        else
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            Vector3 shootDir = enemy.transform.position - transform.position;
            timer += Time.deltaTime;
            if (timer > shootDelay && shootDir.magnitude <= shootRange)
            {
                timer = 0;
                shootDir.Normalize();
                GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = shootDir * shootSpeed;
                Destroy(bullet, bulletLifetime);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCleanup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.layer == 6)
            Destroy(gameObject);
    }
}

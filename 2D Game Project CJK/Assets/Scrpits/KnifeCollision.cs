using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
    public void Start()
    {
    int x = (int)Input.GetAxisRaw("Horizontal");
    if (x < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else if (x > 0)
            GetComponent<SpriteRenderer>().flipX = false;
    }
}

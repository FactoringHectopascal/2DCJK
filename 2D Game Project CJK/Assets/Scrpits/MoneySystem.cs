using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
   
    [SerializeField]
    public int playerStartingMoney;
    [SerializeField]
    public int playerCurrentMoney;
    void Start()
    {
        playerCurrentMoney += playerStartingMoney;
    }

    void Update()
    {
     
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            playerCurrentMoney += 5;
        }
    }
}

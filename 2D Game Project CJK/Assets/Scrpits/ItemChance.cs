using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChance : MonoBehaviour
{
    [SerializeField]
    GameObject necklace;
    [SerializeField]
    GameObject leaf;
    [SerializeField]
    GameObject sunglasses;
    [SerializeField]
    GameObject headphones;
    [SerializeField]
    GameObject hat;
    MoneySystem moneySystem;
    GameObject player;
    int playerCurrentMoney;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moneySystem = player.GetComponent<MoneySystem>();
        int rollForLowTierItem = Random.Range(1, 10);
        playerCurrentMoney = moneySystem.playerCurrentMoney;
        switch (rollForLowTierItem)
        {
            case 1:
                Instantiate(sunglasses, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 2:
                Instantiate(hat, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 3:
                Instantiate(leaf, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 4:
                Instantiate(hat, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 5:
                Instantiate(necklace, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 6:
                Instantiate(sunglasses, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 7:
                Instantiate(sunglasses, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 8:
                Instantiate(necklace, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 9:
                Instantiate(sunglasses, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 10:
                Instantiate(leaf, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
        }    
    }
}

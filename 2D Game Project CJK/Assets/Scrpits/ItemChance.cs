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
    [SerializeField]
    GameObject pendant;
    [SerializeField]
    GameObject pin;
    [SerializeField]
    GameObject medkit;
    // Start is called before the first frame update
    void Start()
    {
        int rollForLowTierItem = Random.Range(1, 10);
        player = GameObject.FindGameObjectWithTag("Player");
        moneySystem = player.GetComponent<MoneySystem>();
        playerCurrentMoney = moneySystem.playerCurrentMoney;
        switch (rollForLowTierItem)
        {
            case 1:
                Instantiate(medkit, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 2:
                Instantiate(pin, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
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
                Instantiate(headphones, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 7:
                Instantiate(sunglasses, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 8:
                Instantiate(necklace, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 9:
                Instantiate(pendant, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 10:
                Instantiate(leaf, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
        }    
    }
}

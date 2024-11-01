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
    [SerializeField]
    GameObject glasses;
    [SerializeField]
    GameObject syringe;
    [SerializeField]
    GameObject drone;
    // Start is called before the first frame update
    void Start()
    {
        int rollForLowTierItem = Random.Range(1, 13);
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
                Instantiate(glasses, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 11:
                Instantiate(syringe, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 12: 
                Instantiate(drone, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;

        }
    }
}
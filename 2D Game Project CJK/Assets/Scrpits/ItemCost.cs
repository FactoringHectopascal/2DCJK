using UnityEngine;

public class ItemCost : MonoBehaviour
{
    [SerializeField]
    int itemCost;
    [SerializeField]
    int itemNumber;
    [SerializeField]
    int itemNumberSet = 1;
    [SerializeField]
    GameObject player;
    [SerializeField]
    int playerCurrentMoney;
    MoneySystem moneySystem;
    
    void Start()
    {
        moneySystem = player.GetComponent<MoneySystem>();
        playerCurrentMoney = moneySystem.playerCurrentMoney;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        playerCurrentMoney = moneySystem.playerCurrentMoney;
        if(playerCurrentMoney >= itemCost && collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Debug.Log("A Successful Purchase!");
            playerCurrentMoney -= itemCost;
            moneySystem.playerCurrentMoney = playerCurrentMoney;
            switch (itemNumberSet)
            {
                case 1:
                    player.GetComponent<PlatformerMovement>().jumpsMax += 1;
                    break;
                case 2:
                    Debug.Log("Bruh");
                    break;
            }
            Destroy(gameObject);
        }
        else if(playerCurrentMoney < itemCost && collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Debug.Log("You're Broke!");
        }
    }

}

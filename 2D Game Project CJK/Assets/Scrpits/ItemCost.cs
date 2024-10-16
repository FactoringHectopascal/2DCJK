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
    PlayerItemBehavior playerItemBehavior;
    void Start()
    {
        moneySystem = player.GetComponent<MoneySystem>();
        playerCurrentMoney = (int)moneySystem.playerCurrentMoney;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        playerCurrentMoney = moneySystem.playerCurrentMoney;
        if(playerCurrentMoney >= itemCost && collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Debug.Log("E");
            switch (itemNumberSet)
            {
                case 1:
                    player.GetComponent<PlayerItemBehavior>().doubleJump = true;
                    playerCurrentMoney -= itemCost;
                    moneySystem.playerCurrentMoney = playerCurrentMoney;
                    Destroy(gameObject);
                    break;
                case 2:
                    player.GetComponent<PlayerItemBehavior>().regen = true;
                    playerCurrentMoney -= itemCost;
                    moneySystem.playerCurrentMoney = playerCurrentMoney;
                    Destroy(gameObject);
                    break;
            }
        }
        else if(playerCurrentMoney < itemCost && collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Debug.Log("You're Broke!");
        }
    }

}

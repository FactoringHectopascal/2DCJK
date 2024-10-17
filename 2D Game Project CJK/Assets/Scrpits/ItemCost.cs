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
                    Debug.Log("Purchased Extra Jump");
                    break;
                case 2:
                    player.GetComponent<PlayerCombat>().attackRate -= 0.05f;
                    Debug.Log("Purchased attackRate Buff");
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

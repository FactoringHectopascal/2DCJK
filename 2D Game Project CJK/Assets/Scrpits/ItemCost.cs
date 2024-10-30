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
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    ItemWearables iW;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moneySystem = player.GetComponent<MoneySystem>();
        playerCurrentMoney = moneySystem.playerCurrentMoney;
        spriteRenderer = GetComponent<SpriteRenderer>();
        iW = player.GetComponent<ItemWearables>();
    }
    private void Update()
    {
        playerCurrentMoney = moneySystem.playerCurrentMoney;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {   if(collision.gameObject.layer == 8)
        {
        spriteRenderer.color = Color.gray;
        }
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
                    iW.wearLeaf();
                    Debug.Log("Purchased Extra Jump");
                    break;
                case 2:
                    player.GetComponent<PlayerCombat>().attackRate -= 0.05f;
                    Debug.Log("Purchased attackRate Buff");
                    iW.wearSunglasses();
                    break;
                case 3:
                    player.GetComponent<PlayerHealth>().maxHealth += 4;
                    iW.wearNecklace();
                    Debug.Log("Purchased More Health");
                    break;
                case 4:
                    player.GetComponent<PlatformerMovement>().coolDownMax -= .4f;
                    player.GetComponent<PlayerHealth>().maxHealth += 3;
                    player.GetComponent<PlatformerMovement>().moveSpeed += .5f;
                    player.GetComponent<PlatformerMovement>().jumpsMax += 1;
                    iW.wearHeadphones();
                    Debug.Log("Purchased Headphones");
                    break;
                case 5:
                    player.GetComponent<PlatformerMovement>().moveSpeed += .6f;
                    iW.wearHat();
                    break;
            }
            Destroy(gameObject);
        }
        else if(playerCurrentMoney < itemCost && collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Debug.Log("You're Broke!");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
        spriteRenderer.color = Color.white;
        }
    }
}

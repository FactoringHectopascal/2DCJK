using System.Collections;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    GameObject sword;
    [SerializeField]
    TextMeshProUGUI costText;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moneySystem = player.GetComponent<MoneySystem>();
        playerCurrentMoney = moneySystem.playerCurrentMoney;
        spriteRenderer = GetComponent<SpriteRenderer>();
        iW = player.GetComponent<ItemWearables>();
        sword = GameObject.FindGameObjectWithTag("sword");
        itemCost = Random.Range(5, 40);
        costText.text = "$ " + itemCost;

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
                    break;
                case 2:
                    player.GetComponent<PlayerCombat>().attackRate -= 0.099f;
                    Debug.Log("Purchased attackRate Buff.");
                    iW.wearSunglasses();
                    break;
                case 3:
                    player.GetComponent<PlayerHealth>().maxHealth += 4;
                    player.GetComponent<PlayerHealth>().health += 4;
                    player.GetComponent<PlayerHealth>().healthBar.fillAmount = player.GetComponent<PlayerHealth>().health / player.GetComponent<PlayerHealth>().maxHealth;
                    iW.wearNecklace();
                    player.GetComponent<PlayerHealth>().text.text = player.GetComponent<PlayerHealth>().health + "/" + player.GetComponent<PlayerHealth>().maxHealth;
                    break;
                case 4:
                    if (player.GetComponent<PlayerHealth>().shieldGot == true)
                        player.GetComponent<PlayerHealth>().shieldCooldown -= 0.25f;
                    else
                    player.GetComponent<PlayerHealth>().shieldGot = true;
                    player.GetComponent<PlayerHealth>().shield = true;
                    iW.wearHeadphones();
                    break;
                case 5:
                    player.GetComponent<PlatformerMovement>().moveSpeed += .6f;
                    iW.wearHat();
                    break;
                case 6:
                    player.GetComponent<PlayerCombat>().attackRadius += 0.099f;
                    sword.transform.localScale += new Vector3 (0.094f, 0.094f, 0);
                    iW.wearPin();
                    break;
                case 7:
                    player.GetComponent<PlayerHealth>().health += player.GetComponent<PlayerHealth>().maxHealth;
                    player.GetComponent<PlayerHealth>().text.text = player.GetComponent<PlayerHealth>().health + "/" + player.GetComponent<PlayerHealth>().maxHealth;
                    player.GetComponent<PlayerHealth>().healthBar.fillAmount = player.GetComponent<PlayerHealth>().health / player.GetComponent<PlayerHealth>().maxHealth;
                    break;
                case 8:
                    player.GetComponent<PlayerCombat>().playerDMG += 5f;
                    iW.wearPendant();
                    break;
                case 9:
                    player.GetComponent<PlatformerMovement>().jumpSpeed += .25f;
                    iW.wearGlasses();
                    break;
                case 10:
                    player.GetComponent<PlatformerMovement>().moveSpeed += .3f;
                    player.GetComponent<PlayerCombat>().attackRate -= .07f;
                    iW.wearSyringe();
                    break;
            }
            Destroy(gameObject);
        }
        else if(playerCurrentMoney < itemCost && collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            return;
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

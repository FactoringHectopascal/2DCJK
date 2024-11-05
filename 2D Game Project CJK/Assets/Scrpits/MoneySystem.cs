using TMPro;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{

    [SerializeField]
    public int playerStartingMoney;
    [SerializeField]
    public int playerCurrentMoney;
    [SerializeField]
    TextMeshProUGUI dollars;
    void Start()
    {
        playerCurrentMoney += playerStartingMoney;
        dollars.text = "Currency: " + playerCurrentMoney;
    }

    void Update()
    {
        dollars.text = "Currency: " + playerCurrentMoney;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        int coinAmount = Random.Range(5, 15);
        if (collision.gameObject.tag == "coin")
        {
            playerCurrentMoney += coinAmount;
        }
    }
}

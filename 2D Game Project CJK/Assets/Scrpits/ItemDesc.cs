using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDesc : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI itemDesc;
    public string description;
    void Start()
    {
        itemDesc.GetComponent<TextMeshProUGUI>().enabled = false;
    }
    public IEnumerator TextDesc()
    {
        itemDesc.GetComponent<TextMeshProUGUI>().enabled = true;
        itemDesc.text = description;
        yield return new WaitForSeconds(2);
        itemDesc.GetComponent<TextMeshProUGUI>().enabled = false;
        StopCoroutine(TextDesc());
    }
}

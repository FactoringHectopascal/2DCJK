using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWearables : MonoBehaviour
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
    public void wearNecklace()
    {
        necklace.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void wearLeaf()
    {
        leaf.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void wearSunglasses()
    {
        sunglasses.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void wearHeadphones()
    {
        headphones.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void wearHat()
    {
        hat.GetComponent<SpriteRenderer>().enabled = true;
    }
}

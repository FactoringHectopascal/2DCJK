using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemBehavior : MonoBehaviour
{
    public bool doubleJump = false;
    public bool regen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ItemBehaviors();
    }
    public void ItemBehaviors()
    {
        if(regen == true)
        {
            Debug.Log("YouBoughtRegen");
        }
        if(doubleJump == true)
        {
            Debug.Log("YouBoughtSmth!");
        }
    }
}

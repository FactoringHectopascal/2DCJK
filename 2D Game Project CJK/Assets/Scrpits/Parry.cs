using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    [SerializeField]
    float parrying = 0f;
    float parryTime = 5f;
    float parryCoolDownCurrent = 0f;
    float parryCoolDownMax = 5f;

    void Update()
    {
        if (parrying > 0f) // if you are parrying
        {
            parrying -= Time.deltaTime; // count down the timer for parrying (so that a player doesn't parry infinitely)
        }
        else
        {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse1) && parryCoolDownCurrent <= 0) // if you press the key and there's no cooldown
        {
            Debug.Log("Parry!"); //Do Something, Like Negate Damage.
            parryCoolDownCurrent = parryCoolDownMax; // reset the cooldown
            parrying = parryTime; // start the timer for parrying
        }
        else
        {
            parryCoolDownCurrent -= Time.deltaTime; // Count down the cooldown for parrying
        }
        }
    }
}

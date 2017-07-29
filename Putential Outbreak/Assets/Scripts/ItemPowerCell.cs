using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowerCell : Item {

    public float PowerValue;

    protected override void Pickup()
    {
        base.Pickup();

        GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.AddPower(PowerValue);
    }
}

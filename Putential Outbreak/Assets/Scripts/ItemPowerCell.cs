using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowerCell : Item {

    public float PowerValue;

    protected override void Pickup()
    {
        base.Pickup();

        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.HasPowerCell = true;

        Destroy(gameObject);
    }
}

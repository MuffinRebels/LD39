using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealthPack : Item {

    public int Health = 5;

	protected override void Pickup()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.ModifyHealth(Health);
    }

}

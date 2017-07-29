using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PowerStation : MonoBehaviour
{
    public float PowerCellPowerValue = 1.0f;

    private BoxCollider2D _collider;
    private bool _isInRange = false;
    private bool _poweredOn = false;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isInRange = false;
        }
    }

    private void Update()
    {
        // TODO: Show UI saying "Press E to pickup {ItemName}
        if (Input.GetKeyDown(KeyCode.E) && _isInRange)
            Activate();
    }

    protected virtual void Activate()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player.HasPowerCell)
        {
            player.HasPowerCell = false;
            _poweredOn = true;
            GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gameManager.AddPower(PowerCellPowerValue);
            // TODO: UI!
            Debug.Log("Powered on this station");
        } else
        {
            // TODO: UI!
            Debug.Log("You don't have a power cell");
        }
    }

}

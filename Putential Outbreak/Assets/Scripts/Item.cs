using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour {

    public string ItemName;
    public int id;

    private BoxCollider2D _collider;
    private bool _isInRange = false;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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
            Pickup();
    }

    protected virtual void Pickup()
    {
        Debug.Log("Picked up " + ItemName);
    }

}

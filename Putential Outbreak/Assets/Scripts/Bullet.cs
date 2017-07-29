using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour {

    public float Speed = 1f;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += transform.right * Speed;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            DestroyBullet();
    }

    private void DestroyBullet()
    {
        // TODO: Play particle system
        Destroy(gameObject);
    }
}

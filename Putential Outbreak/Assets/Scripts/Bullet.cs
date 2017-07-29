using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour {

    public float Speed = 1f;

    [SerializeField]
    private AudioClip _hitSound;

    // Update is called once per frame
    void FixedUpdate () {
        transform.position += transform.right * Speed;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            DestroyBullet();

        DestroyBullet();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            DestroyBullet();
    }

    private void DestroyBullet()
    {
        if (_hitSound != null)
            AudioSource.PlayClipAtPoint(_hitSound, transform.position);
        // TODO: Play particle system
        Destroy(gameObject);
    }
}

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
}

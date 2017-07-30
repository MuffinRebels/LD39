using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameaFollow : MonoBehaviour {

    public Transform target;
    public float smoothness;
	
	void FixedUpdate () {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.position.x, smoothness),
                                         Mathf.Lerp(transform.position.y, target.position.y, smoothness), transform.position.z);
	}
}

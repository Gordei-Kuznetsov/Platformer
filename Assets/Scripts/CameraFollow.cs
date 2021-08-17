using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Rigidbody target;    
	
	void Update () {
		if(target != null) {
			gameObject.transform.position = target.position;
		}
	}
}

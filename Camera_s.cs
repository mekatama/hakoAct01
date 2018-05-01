using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_s : MonoBehaviour {
	public float moveSpeed;	//cameraの移動speed

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(moveSpeed, 0, 0));
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Title : MonoBehaviour {
	public GameObject player_Title = null;	//playerプレハブ
	public float timeOut = 1.5f;			//playerの連射間隔
	private float timeElapsed = 0.0f;		//playerの連射間隔カウント用
	
	void Update () {
		timeElapsed += Time.deltaTime;
        if(timeElapsed >= timeOut) {
			Instantiate( player_Title, transform.position, transform.rotation);
			timeElapsed = 0.0f;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public int num_coin = 0;	//coinの数

	void Start () {
	}
	
	void Update () {
		Debug.Log("coin;" + num_coin);
	}
}

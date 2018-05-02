using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Wall : MonoBehaviour {
	GameObject gameController;	//gameController入れる用

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");		//GameControllerオブジェクトを探す
	}
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//Goal_Wall消すかどうか判定
		if(gc.isClearCoin == true){
			Destroy(gameObject);
		}
	}
}

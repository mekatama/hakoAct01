using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
	public GameObject gameController;	//GameController取得
	private bool in_Goal;				//
	
	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();
			if(gc.isClearCoin == true){
				//
				gc.inGoal = true;
			}
		}
	}
}

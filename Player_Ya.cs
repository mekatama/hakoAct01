using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ya : MonoBehaviour {
	public GameObject gameController;	//GameController取得
	public 	Transform _target; 			//矢印の向くオブジェクト

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (_target.position);

		//表示on/off
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		if(gc.isClearCoin){
			this.transform.localScale = new Vector3(1, 1, 1);
		}else{
			this.transform.localScale = new Vector3(0, 0, 0);
		}


	}
}

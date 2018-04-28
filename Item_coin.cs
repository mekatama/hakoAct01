using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_coin : MonoBehaviour {
	public int coin;			//coinの数
	GameObject gameController;	//gameController入れる用

	void Start () {
		coin = 1;	//初期化
		gameController = GameObject.FindWithTag ("GameController");		//GameControllerオブジェクトを探す
	}

	void Update(){
		//coin毎フレーム回転
		transform.Rotate(new Vector3(0.0f, 0.0f, 5.0f));
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			//coin加算
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();
			//GameControllerで管理しているスコア表示用の変数を使って計算
			gc.num_coin = gc.num_coin + coin;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_coin : MonoBehaviour {
	public GameObject gameController;	//GameController取得
	public Text coinText;				//Textコンポーネント取得用
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//coin数表示
		coinText.text = gc.num_coin.ToString("00000");
	}

}

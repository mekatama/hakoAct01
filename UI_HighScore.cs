using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HighScore : MonoBehaviour {

	public GameObject gameController;	//GameController取得
	public Text highScoreText;			//Textコンポーネント取得用

	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//time表示
		highScoreText.text = gc.highScoreTime.ToString("000.000");
	}
}

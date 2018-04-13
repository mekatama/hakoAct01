﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_time : MonoBehaviour {
	public GameObject gameController;	//GameController取得
	public Text timeText;				//Textコンポーネント取得用

	//ゲームステート
	enum State{
		Ready,
		Play,
		Result,
		AllResult
	}
	State state;

	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//time表示
		timeText.text = gc.timeCount.ToString("000.000");
	}
}

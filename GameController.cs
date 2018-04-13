using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public int num_coin = 0;	//coinの数
	public int clear_coin = 2;	//clearに必要なコイン数
	public bool isClear;		//clear flag
	public float timeCount;		//play時間

	public Canvas clearCamvas;	//clear

	void Start () {
		isClear = false;				//初期化
		clearCamvas.enabled = false;	//StartUI非表示
	}
	
	void Update () {
		//timeカウント
		timeCount += Time.deltaTime;	//play時間の保存
		Debug.Log(timeCount);

		//クリア判定
		if(clear_coin == num_coin){
			clearCamvas.enabled = true;	//StartUI表示
			isClear = true;				//clear flag on
		}
//		Debug.Log("coin;" + num_coin);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Coin : MonoBehaviour {
	public GameObject coinObj;		//coinのプレハブ
	public GameObject[] coinPos;	//coinの出現位置を配列で管理
	private int spawn_Count;		//配置するコインをカウント(0スタート)

	void Start () {
		//配置数だけloopする
		for(int i = 0; i < coinPos.Length; i++){
			spawn_Count = i;	//カウント代入
			CoinGo();			//関数呼び出し
		}
	}
	
	void Update () {
	}

	public void CoinGo(){
		//coin生成
		Instantiate(
			coinObj,									//生成するcoin
			coinPos[spawn_Count].transform.position,	//生成時の位置
			coinPos[spawn_Count].transform.rotation		//生成時の角度
		);
	}
}

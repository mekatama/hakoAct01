using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Coin : MonoBehaviour {
	public GameObject coinObj;		//coinのプレハブ
	public GameObject[] coinPos;	//coinの出現位置を配列で管理
	private int spawn_Count;		//配置するコインをカウント(0スタート)
	private int ransu;				//乱数保存用
	private int start = 1;			//coin生成point:最小値
	public int spawn_Num = 3;		//coin生成したい個数
	List<int> numbers = new List<int>();	//全てのcoin生成pointのindexを入れる

	void Start () {
		//Listに全てのcoin生成pointのindexを入れる
		for (int i = start; i <= coinPos.Length; i++) {
			numbers.Add(i);
		}

		//生成したいcoin数で回す
		while (spawn_Num-- > 0) {
			//List要素数でrandom
			int index = Random.Range(0, numbers.Count);
			//乱数を取り出す
			ransu = numbers[index];
//			Debug.Log(ransu);
			//取り出した数値を削除。これで重複しなくなる
 			numbers.RemoveAt(index);
			CoinGo();			//関数呼び出し
		}
	}
	
	void Update () {
	}

	public void CoinGo(){
		//coin生成
		Instantiate(
			coinObj,									//生成するcoin
			coinPos[ransu - 1].transform.position,		//生成時の位置
			coinPos[ransu - 1].transform.rotation		//生成時の角度
		);
	}
}

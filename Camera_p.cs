using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_p : MonoBehaviour {
	Vector3 diff;				//起動時のカメラとプレイヤーの位置関係
	public float followSpeed;	//補間スピード
	GameObject player;			//オブジェクト入れる用

	void Start () {
		player = GameObject.FindWithTag ("Player");		//Playerオブジェクトを探す
		//pcって仮の変数にPlayerのコンポーネントを入れる
		Player pc = player.GetComponent<Player>();
		diff = pc.transform.position - transform.position;	//追従距離の計算
	}
	
	void LateUpdate () {
		//pcって仮の変数にPlayerのコンポーネントを入れる
		Player pc = player.GetComponent<Player>();
		//線形補間関数を使用
		transform.position = Vector3.Lerp(
			transform.position,
			pc.transform.position - diff,
			Time.deltaTime * followSpeed
		);
	}
}

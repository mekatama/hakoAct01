using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	CharacterController characterController;//コンポーネントを入れる用
	Animator animator;
	Vector3 moveDirection = Vector3.zero;
	public float graviy;
	public float speedZ;

	void Start () {
		characterController = GetComponent<CharacterController>();	//コンポーネントを取得
//		animator = GetComponent<Animator>();						//コンポーネントを取得
	}
	
	void Update () {
		//地上にいる時の処理
		if(characterController.isGrounded){
//			moveDirection.y -= graviy * Time.deltaTime;	//重力の加算
		}
		//地上にいる時
		else{
			moveDirection.y -= graviy * Time.deltaTime;	//重力の加算
		}

		//移動実行
		Vector3 globalDirection = transform.TransformDirection(moveDirection);
		characterController.Move(globalDirection * Time.deltaTime);
	}
}

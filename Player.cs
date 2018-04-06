using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	CharacterController characterController;//コンポーネントを入れる用
	Animator animator;
	public float graviy;

	private float rayRange = 1000f;		//レイを飛ばす距離
	private Vector3 targetPosition;		//移動する位置
	private Vector3 velocity;			//速度
	private float moveSpeed = 1.5f;		//移動スピード

	void Start () {
		characterController = GetComponent<CharacterController>();	//コンポーネントを取得
		animator = GetComponent<Animator>();	//コンポーネントを取得
		targetPosition = transform.position;	//playerの位置
		velocity = Vector3.zero;				//0ベクトル
	}

	void Update () {
		//地上にいる時の処理
		if(characterController.isGrounded){
			velocity = Vector3.zero;
			//マウスクリックの位置を移動する位置にする
			if(Input.GetMouseButtonDown(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit, rayRange, LayerMask.GetMask ("Field"))) {
					targetPosition = hit.point;
				}
			}

			//　移動の目的地と0.1mより距離がある時は速度を計算
			if(Vector3.Distance(transform.position, targetPosition) > 0.1f) {
				var moveDirection = (targetPosition - transform.position).normalized;
				velocity = new Vector3(moveDirection.x * moveSpeed, velocity.y, moveDirection.z * moveSpeed);
				transform.LookAt(transform.position + new Vector3(moveDirection.x, 0, moveDirection.z));
			}
		}
		//地上にいない時
		else{
			velocity.y -= graviy * Time.deltaTime;	//重力の加算
		}

		//移動実行
		characterController.Move(velocity * Time.deltaTime);
	}
}

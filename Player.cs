﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameObject gameController;	//GameController取得
	CharacterController characterController;//コンポーネントを入れる用
	Animator animator;
	public float graviy;

	private float rayRange = 1000f;		//レイを飛ばす距離
	private Vector3 targetPosition;		//移動する位置
	private Vector3 velocity;			//速度
	private float moveSpeed = 1.5f;		//移動スピード
	public bool isWalk;					//移動flag

	AudioSource audioSource;			//AudioSourceコンポーネント取得用
	public AudioClip audioClipCoin;		//coin SE
	public AudioClip audioClipClear;	//clear SE
	private bool onceClearCoin;			//一回だけ処理用

	void Start () {
		characterController = GetComponent<CharacterController>();	//コンポーネントを取得
		animator = GetComponent<Animator>();	//コンポーネントを取得
		targetPosition = transform.position;	//playerの位置
		velocity = Vector3.zero;				//0ベクトル
		isWalk = false;							//移動flag初期化
		audioSource = gameObject.GetComponent<AudioSource>();		//AudioSourceコンポーネント取得
		onceClearCoin = false;					//初期化
	}

	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();

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
				isWalk = true;	//移動flag on
			}else{
				isWalk = false;	//移動flag off
			}
		}
		//地上にいない時
		else{
			velocity.y -= graviy * Time.deltaTime;	//重力の加算
		}

		//入力許可onで移動
		if(gc.isInPut){
			//移動実行
			characterController.Move(velocity * Time.deltaTime);
		}else{
			isWalk = false;	//移動flag off
		}
		animator.SetBool("isWalk", isWalk);		//animation制御

		//goal侵入flag onで
		if(gc.inGoal){
			animator.SetBool("isFun", true);		//animation制御
			//clear se 再生判定
			if(onceClearCoin == false){
				audioSource.clip = audioClipClear;	//SE決定
				audioSource.Play ();				//SE再生
				onceClearCoin = true;
			}
		}


	}
	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other) {
		if(other.tag == "coin"){
			audioSource.clip = audioClipCoin;	//SE決定
			audioSource.Play ();				//SE再生
		}
	}
}

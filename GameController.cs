﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int num_coin = 0;	//coinの数
	public int clear_coin = 2;	//clearに必要なコイン数
	public bool isClear;		//clear flag
	public bool isClearCoin;	//goal open flag
	public float timeCount;		//play時間
	public bool inGoal;			//goal侵入flag
	public bool isInPut;		//入力許可flag
	private bool isTimeCount;	//時間開始flag
	public float highScoreTime;	//ハイスコア

	private GameObject MainCam;	//mein camera
	private GameObject SubCam;	//sub camera
	private float time = 0.0f;	//demo cameraの再生時間

	public Canvas clearCamvas;		//UI clear
	public Canvas inGameCamvas;		//UI inGame
	public Canvas highScoreCamvas;	//UI hiScore

	//ゲームステート
	enum State{
		Ready,		//deno
		Play,		//inGame
		GoalOpen,	//
		Clear,		//
		AllClear	//
	}
	State state;


	void Start () {
		isClear = false;					//初期化
		isClearCoin = false;				//初期化
		inGoal = false;						//初期化
		isInPut = false;					//初期化
		isTimeCount = false;				//初期化
		clearCamvas.enabled = false;		//UI非表示
		inGameCamvas.enabled = false;		//UI非表示
		highScoreCamvas.enabled = false;	//UI非表示

		MainCam = GameObject.Find("Main Camera");
		SubCam = GameObject.Find("Sub Camera");
		MainCam.SetActive(false);		//main camera off

		//HighScoreがなかったら０を入れて初期化
		highScoreTime =	PlayerPrefs.GetFloat("HighScore", 100f); 

		Ready();						//ステート変更
	}
	void LateUpdate () {
		//ステートの制御
		switch(state){
			//demo
			case State.Ready:
				Debug.Log("Load : " + highScoreTime);
				time += Time.deltaTime;		//demo camera 再生時間増やす
				if(time > 2.0f){			//1秒でin game に移行
					isInPut = true;
					Play();					//ステート変更
				}
				break;
			//
			case State.Play:
				inGameCamvas.enabled = true;	//UI表示
				isTimeCount = true;				//時間開始
				//カメラ切り替え
				MainCam.SetActive (true);	//main camera on
				Debug.Log("State.Ready");
				SubCam.SetActive (false);	//sub camera off

				Debug.Log("State.Play");
				//coin判定
				if(clear_coin == num_coin){
					isClearCoin = true;
					GoalOpen();							//ステート変更
				}
				break;
			//
			case State.GoalOpen:
				Debug.Log("State.GoalOpen");
				//判定
				if(inGoal == true){
					isInPut = false;
					Clear();							//ステート変更
				}
				break;
			//
			case State.Clear:
				Debug.Log("clear time : " + timeCount);
				//ハイスコア判定
				if(highScoreTime > timeCount){
					HighScore();					//ハイスコア処理関数
				}

				inGameCamvas.enabled = false;	//UI非表示
				clearCamvas.enabled = true;		//clearUI表示
				isClear = true;					//clear flag on

				Debug.Log("State.Clear");
				break;
			//
			case State.AllClear:
				Debug.Log("State.AllClear");
				break;
		}
	}	

	void Update () {
		//timeカウント(clearで停止)
		if(isTimeCount){
			if(isClear == false){
				timeCount += Time.deltaTime;	//play時間の保存
			}
		}
	}

	void Ready(){
		state = State.Ready;
	}
	void Play(){
		state = State.Play;
	}
	void GoalOpen(){
		state = State.GoalOpen;
	}
	void Clear(){
		state = State.Clear;
	}
	void AllClear(){
		state = State.AllClear;
	}

	void HighScore(){
//		highScoreCamvas.enabled = true;						//highScoreUI表示
		highScoreTime = timeCount;							//ハイスコア更新
		PlayerPrefs.SetFloat("HighScore", highScoreTime);	//save
		highScoreCamvas.enabled = true;						//UI表示
		Debug.Log("HighScore更新:" + highScoreTime);
	}

	//タイトル画面に戻るボタン用の制御関数
	public void OnTitleButtonClicked(){
		SceneManager.LoadScene("Title");	//シーンのロード
	}

}

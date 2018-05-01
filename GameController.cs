using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public int num_coin = 0;	//coinの数
	public int clear_coin = 2;	//clearに必要なコイン数
	public bool isClear;		//clear flag
	public bool isClearCoin;	//
	public float timeCount;		//play時間
	public bool inGoal;			//goal侵入flag

	private GameObject MainCam;	//mein camera
	private GameObject SubCam;	//sub camera
	private float time = 0.0f;	//demo cameraの再生時間

	//ゲームステート
	enum State{
		Ready,		//deno
		Play,		//inGame
		GoalOpen,	//
		Clear,		//
		AllClear	//
	}
	State state;

	public Canvas clearCamvas;	//clear

	void Start () {
		isClear = false;				//初期化
		isClearCoin = false;			//初期化
		inGoal = false;					//初期化
		clearCamvas.enabled = false;	//StartUI非表示

		MainCam = GameObject.Find("Main Camera");
		SubCam = GameObject.Find("Sub Camera");
		MainCam.SetActive(false);		//main camera off

		Ready();						//ステート変更
	}
	void LateUpdate () {
		//ステートの制御
		switch(state){
			//demo
			case State.Ready:
				time += Time.deltaTime;		//demo camera 再生時間増やす

				//ここにカメラ移動処理入れたい

				if(time > 1.0f){			//1秒でin game に移行
					Play();					//ステート変更
				}
				Debug.Log("State.Ready");
				break;
			//
			case State.Play:
				//カメラ切り替え
				MainCam.SetActive (true);	//main camera on
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
					Clear();							//ステート変更
				}
				break;
			//
			case State.Clear:
				clearCamvas.enabled = true;	//clearUI表示
				isClear = true;				//clear flag on
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
		if(isClear == false){
			timeCount += Time.deltaTime;	//play時間の保存
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

}

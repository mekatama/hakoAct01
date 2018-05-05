using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

	void Update(){
		//backキー
		if (Input.GetKeyUp(KeyCode.Escape)){
			Application.Quit();	//アプリ終了
		}
	}

	//セレクト画面用の制御関数
	public void OnStageButtonClicked(){
		SceneManager.LoadScene("Stage01");	//シーンのロード
	}

	//遊び方ボタン用の制御関数
	public void OnHowToPlayButtonClicked(){
		SceneManager.LoadScene("HowToPlay");	//シーンのロード
	}

	//戻るボタン用の制御関数
	public void OnTitleButtonClicked(){
		SceneManager.LoadScene("Title");	//シーンのロード
	}
	
	//アプリ終了
	public void OnExitButtonClicked(){
		Application.Quit();
		Debug.Log("exit");	
	}

	//Debug用ハイスコアリセットボタン
//	public void OnResetButtonClicked(){
//		PlayerPrefs.DeleteAll();
//		Debug.Log("全データ削除しますた");	
//	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	//移動するクラスを格納する配列
	Move[] MV=new Move[4];

	//衝突した時間を保持する変数
	float GetTime=0;

	//操作不能を解除する関数
	public float OpenTime;

	// Update is called once per frame
	void Update () {
		//OpenTime分の時間が立ったら
		if (GetTime + OpenTime < Time.time) {

			//操作不能を解除する関数を呼び出し
			MoveRevive ();
		}
	}

	//操作不能を解除する関数
	void MoveRevive(){
		for (int i = 0; i < MV.Length; i++) {

			//格納されたスクリプトが無くなったら終了
			if (MV [i] == null)break;

			//格納されたスクリプトをTrueへ
			MV [i].enabled = true;
		}
	}

	//操作不能時間を管理するタイマー関数(引数：不能にするクラスの型)
	public void Timer(Move move){

//		if (move.gameObject.name == "Sphere1") {
			//移動するScriptの状態をFalseへ
			move.enabled = false;
//		} else {
//		}

		for(int i=0;i<MV.Length;i++){
			if (MV [i] == null) {

				//移動するクラスを格納
				MV [i]=move;
				break;
			}
		}

		//衝突した時間を取得
		GetTime = Time.time;

	}
}

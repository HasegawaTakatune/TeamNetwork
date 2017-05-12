﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	float speed;//移動速度
	public string left;
	public string right;
	public string up;
	public string down;

	Move_Ai Ai;
	bool AiFlg;

	//ステージ上にいるかを保持する変数
	public bool liveflg;

	float ReviveTime;//復帰する時間,10~20間で調整

	GameController GC;

	bool Moveflg;

	float FloorPosY;

	void Start(){
		GC = GameObject.Find ("GameController").GetComponent<GameController> ();
		speed = GC.speed;
		ReviveTime = GC.ReviveTime;

		Ai=this.GetComponent<Move_Ai> ();

		//Aiかを判断する関数
		AiSerch ();
	}
	// Update is called once per frame
	void Update () {
		//復帰する
		Revive ();
		if (FloorPosY-0.01 <= this.transform.position.y) {
			MoveOn ();
		}

	}

	/// <summary>
	/// PlayerモードとAiモードかを振り分ける関数
	/// </summary>
	void AiSerch(){
		//スクリプトが無いか、非アクティブならPlayerモードへ
		if (Ai==null||Ai.enabled==false) {
			AiFlg = false;
			//そうでないならAiモードへ
		} else {
			AiFlg = true;
		}
	}

	/// <summary>
	/// 復帰する関数
	/// </summary>
	void Revive(){
		if (this.transform.position.y < -ReviveTime) {
			this.transform.position = new Vector3 (0f, 2f, 0f);
		}
	}

	void MoveOn(){
		if (AiFlg == true) {
			Ai.Move ();
		} else {
			//左
			if (Input.GetKey (left)) {
				this.transform.position = new Vector3 (this.transform.position.x - speed, this.transform.position.y, this.transform.position.z);
			}
			//右
			if (Input.GetKey (right)) {
				this.transform.position = new Vector3 (this.transform.position.x + speed, this.transform.position.y, this.transform.position.z);
			}
			//上
			if (Input.GetKey (up)) {
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + speed);
			}
			//下
			if (Input.GetKey (down)) {
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - speed);
			}
		}
	}

	void OnCollisionEnter(Collision col){
		//床に触れた時
		if (col.gameObject.name=="floor") {
			FloorPosY=this.transform.position.y;
			liveflg = true;
		}
	}
	void OnCollisionExit(Collision col){
		//床から離れた時
		if (col.gameObject.name == "floor") {
			liveflg = false;
		}
	}
}

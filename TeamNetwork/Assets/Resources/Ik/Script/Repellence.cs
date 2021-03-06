﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repellence : MonoBehaviour {

	GameController GC;

	Move MV;

	//押し出す力(基本１００～２００間で調整)
	public float power;

	void Start(){
		//ゲームコントローラークラス
		GC = GameObject.Find ("GameController").GetComponent<GameController>();

		//自分の移動するクラス
		MV = GameObject.Find (this.gameObject.name).GetComponent<Move>();
	}

	//enemyの反対側へ押し出す関数
	void Rep(GameObject enemy){
		
		//相手の反対側へ,相手との距離＊power倍の力で押し出す
		enemy.GetComponent<Rigidbody> ().AddForce ((enemy.transform.position - this.transform.position)*power);
	}

	//一定時間操作不能にする
	void Pause(){

		if (MV.enabled == true)
		//ゲームコントローラークラスのタイマーを呼ぶ
		GC.Timer (MV);
	}

	void OnCollisionEnter(Collision col){
		//Rep(衝突した相手(GameObject))
		Rep(col.gameObject);
		//一定時間操作不能にする
		Pause();
	}

}

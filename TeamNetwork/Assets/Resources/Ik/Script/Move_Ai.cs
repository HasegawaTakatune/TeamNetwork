using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Ai : MonoBehaviour {

	Vector3 movetrans;

	[SerializeField]
	GameObject enemy;

	float GetTime;

	[SerializeField]
	float OpenTime;

	int dbgcnt=0;

	float kyori;

	[SerializeField]
	float speed;

	[SerializeField]
	float speed_range;

	int vectr;

	Vector2 floor_min=new Vector2(-2,-2);
	Vector2 floor_max=new Vector2(2,2);
	// Use this for initialization
	void Start () {
//		enemy = GameObject.Find ("Sphere1");
		Target ();
	}


	public void Move(){
		if (GetTime + OpenTime < Time.time) {
			Target ();
			GetTime = Time.time;
		}
		this.transform.position -= new Vector3(movetrans.x/30f,0,movetrans.z/30f);
	}
		
	void Target(){
		movetrans.x = this.transform.position.x - enemy.transform.position.x;
		movetrans.z = this.transform.position.z - enemy.transform.position.z;
		kyori=Mathf.Sqrt ((movetrans.x * movetrans.x) + (movetrans.z * movetrans.z));
		while (kyori > speed+speed_range || kyori < speed-speed_range) {
			if (kyori > speed+speed_range) {
				movetrans.x /= 1.25f;
				movetrans.z /= 1.25f;
			} else if (kyori < speed-speed_range) {
				movetrans.x *= 1.25f;
				movetrans.z *= 1.25f;
			}
			kyori = Mathf.Sqrt ((movetrans.x * movetrans.x) + (movetrans.z * movetrans.z));
			dbgcnt++;
			if (dbgcnt > 50) {
				Debug.Log ("dbgout");
				dbgcnt = 0;
				break;
			}
		}/*
		if (this.transform.position.x > enemy.transform.position.x + 1.5f) {
			movetrans.x = 4;
		} else if (this.transform.position.x < enemy.transform.position.x - 1.5f) {
			movetrans.x = -4;
		} else {
			movetrans.x = 0;
		}
		if (this.transform.position.z > enemy.transform.position.z + 1.5f) {
			movetrans.z = 4;
		} else if (this.transform.position.z < enemy.transform.position.z - 1.5f) {
			movetrans.z = -4;
		} else {
			movetrans.z = 0;
		}
		if (movetrans.x == 4 && movetrans.z == 4)vectr = 0;
		if(movetrans.x==4&&movetrans.z==0)vectr = 1;
		if(movetrans.x==4&&movetrans.z==-4)vectr = 2;
		if(movetrans.x==0&&movetrans.z==4)vectr = 3;
		if(movetrans.x==0&&movetrans.z==0)vectr = 4;
		if(movetrans.x==0&&movetrans.z==-4)vectr = 5;
		if(movetrans.x==-4&&movetrans.z==4)vectr = 6;
		if(movetrans.x==-4&&movetrans.z==0)vectr = 7;
		if(movetrans.x==-4&&movetrans.z==-4)vectr = 8;*/
		Dodge ();
	}

	//避ける関数
	void Dodge(){
		int Dodgeflg;
		//避けるかどうかを判定
//		Dodgeflg=Random.Range (0,1);
		Dodgeflg=0;
		if (Dodgeflg == 0) {
			//避ける
			//相手の進んでいる方向を検出
			//自分の先が未知数なら
			Debug.Log(this.transform.position.x+"_"+movetrans.x);
			if(this.transform.position.x+movetrans.x<floor_min.x){
				movetrans.x = 0f;
			}
			if(this.transform.position.z+movetrans.z<floor_min.y){
				movetrans.z = 0f;
			}
			if(this.transform.position.x+movetrans.x>floor_max.x){
				movetrans.x = 0f;
			}
			if(this.transform.position.z+movetrans.z>floor_max.y){
				movetrans.z = 0f;
			}
			/**自分の方に向かってきているかが検出できない**/
			//自分の避ける方向を判定
			Debug.Log(floor_min+"_"+floor_max);
						
		} else {//避けない
		}			

	}
/*	void OnCollisionStay(Collision col){
		if (col.gameObject.name == "floor") {
			if (this.transform.position.x < floor_min.x) {
				floor_min.x = this.transform.position.x;
			}
			if (this.transform.position.z < floor_min.y) {
				floor_min.y = this.transform.position.z;
			}
			if (this.transform.position.x > floor_max.x) {
				floor_max.x = this.transform.position.x;
			}
			if (this.transform.position.z > floor_max.y) {
				floor_max.y = this.transform.position.z;
			}
		}
	}
*/}

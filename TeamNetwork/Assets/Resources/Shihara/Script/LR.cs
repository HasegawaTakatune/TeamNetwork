using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR : MonoBehaviour {
    public float move_x;
    float count;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        count += Manager.GameCount;
        transform.Translate(move_x, 0.0f, 0.0f);

        if (count > 2)
        {
            move_x = move_x * -1;
            count = 0; 
        }
    }
}

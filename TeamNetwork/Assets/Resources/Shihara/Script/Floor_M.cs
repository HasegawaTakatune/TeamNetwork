using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_M : MonoBehaviour {

    public float Belt_speed;

    // Use this for initialization
    void Start()
    {

    }

    //床に乗ったら
    void OnCollisionEnter(Collision other)
    {
        var body = other.gameObject.GetComponent<Rigidbody>();
        if (body != null)
        {
            Vector3 add = transform.forward * Belt_speed; 
            body.AddForce(add, ForceMode.Acceleration);
        }
    }

    //床から降りたら
   /* void OnCollisionExit(Collision other)
    {
        var body = other.gameObject.GetComponent<Rigidbody>();
        if( body != null)
        {
            Vector3 add = -transform.forward * Belt_speed;
            body.AddForce(add, ForceMode.Acceleration);
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_E : MonoBehaviour
{
    public float move_y;
    float count;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count += Manager.GameCount;


        if (count > 2)
        {

            if (count > 2)
            {
                move_y = move_y * -1;
                count = 0;
            }
        }
    }
}

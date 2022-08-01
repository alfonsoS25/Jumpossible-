using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool RightRotate = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (RightRotate == true)                        //if the player speed is positive  rotate the player parent to right
        {
            transform.Rotate(0, 0, 3);
        }
        else                                            //if the player speed is negative  rotate the player parent to left
        {
            transform.Rotate(0, 0, -3);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField]
    private float JumpForceVertical;

    [SerializeField]
    private float jumpForceHorizontal;

    [SerializeField]
    private float rotationForce;


    private void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))                   //if hits a player, make it jump with the attached vertical force, horizontal force and rotation force on unity
        {
            collision.gameObject.GetComponent<Player>().JumpPadForce(rotationForce, jumpForceHorizontal, JumpForceVertical);
        }
    }
}

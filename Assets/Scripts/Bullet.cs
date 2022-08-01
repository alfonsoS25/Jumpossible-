using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float movement = 0.15f;                                                   //object speed
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(movement, 0, 0);                                  //move forward
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))                                                   //if hits player
        {
            Vector2 hitForce = new Vector2(0f,0);
            hitForce.x = this.gameObject.transform.position.x - collision.gameObject.transform.position.x;                //gets the position between of this object and the enemy object
            hitForce.y = -0.2f;
            hitForce = hitForce * -2000;                 
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(hitForce);                                        //puts knockback force to the player
            Destroy(this.gameObject);                                               
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);                           //if hits ground, just destroy this
        }
    }
}

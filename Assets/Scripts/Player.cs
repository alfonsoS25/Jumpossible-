using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool ontimeuse = false;
    private Rigidbody2D Rigid;                  //player rigidbody

    [SerializeField]
    private LayerMask Layer;                    //layer for the grapple

    [SerializeField]

    private GameObject Parenter = null;                  //rotation parent

    private Transform Pollisher;

    bool Rotating = false;                          //if its rotating

    bool positiveSpeed = false;                     //if this object velocity its positive

    float Rotator;                              
    [SerializeField]
    private int howmanyjumps = 2;

    private GameObject orb;
    public float radius;
    public float radiusSpeed;
    public float rotationSpeed;

    private Transform centre;
    private Vector3 desiredPos;

    enum PlayerState
    {
        Moving,
        Rotating
    }
    PlayerState playerState = PlayerState.Moving;

    Vector2 ActualSpeed = new Vector2(0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Rotating == false)
        {
            if (Input.GetKey(KeyCode.A) && Rigid.velocity.x > -4)           //when press key A, add force to left
            {
                Rigid.AddForce(new Vector2(-55, 0));                
            }
         
            if (Input.GetKey(KeyCode.D) && Rigid.velocity.x < 4)            //when press key D, add force to right
            {
                Rigid.AddForce(new Vector2(55, 0));
            }
        }
    }
    private void Update()
    {
        switch (playerState)
        {
            case PlayerState.Moving:

                if (Input.GetMouseButtonDown(0))                                    //when mouse button is pressed
                {
                    StartGrapple();                                                 //strats grapple
                }
                if (Rotating == false)
                {
                    if (Input.GetKeyDown(KeyCode.W) && howmanyjumps > 0)                       //if W is pressed, make the player jump
                    {
                        Rigid.AddForce(new Vector2(0, 500));
                        howmanyjumps--;                                                         //rest 1 jump from max jumps
                    }
                }
            break;


            case PlayerState.Rotating:

                Rigid.transform.RotateAround(centre.position, Vector3.forward, rotationSpeed * Time.deltaTime);
                desiredPos = (Rigid.transform.position - centre.position).normalized * radius + centre.position;
                //Rigid.transform.position = Vector3.MoveTowards(Rigid.transform.position, desiredPos, radiusSpeed * Time.deltaTime);

                if (Input.GetMouseButton(0))                                        //while mouse button is pressed
                {
                    Rotator += Time.deltaTime;                                  //sums time to rotator
                }

                if (Input.GetMouseButtonUp(0))                                  //when mouse button is relased
                {
                    Rotator = Rotator % 2.5f;                                         //if the grapple is over 1.25 seconds make the player speed to -
                    if (Rotator > 1.25f)
                    {
                        ActualSpeed.x *= -1f;
                    }
                    Rotator = 0;                                            //resets the grapple
                    EndGrapple();                                               //ends the grapple
                }
            break;
        }

        if(this.transform.position.y < -15f)                         //  if this object goes less than -15 in y direction
        {
            var GenerateNewPlayer = GameObject.Find("GameManager");         //search the gamemanager
            GenerateNewPlayer.GetComponent<GameManager>().GeneratePlayer();     //Spawn a new Player            
            Destroy(this.gameObject);                                               //delete this gameObject
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))               //if hits the ground
        {if (Rotating == true)
            {
                EndGrapple();                           //ends the grapple if is casted
            }                            
        }
        if(collision.gameObject.CompareTag("DeathZone"))                //if player touches deadzone
        {
            var GenerateNewPlayer = GameObject.Find("GameManager");
            var CameraShake = GameObject.Find("Main Camera");                       //shake the camera
            GenerateNewPlayer.GetComponent<GameManager>().GeneratePlayer();         //resets the player
            CameraShake.GetComponent<CameraEffects>().shake();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))              //while being in ground
        {
            if (howmanyjumps == 0)
            {
                howmanyjumps = 2;                                //resets jump
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))                     //if hit the goal
        {
            if (ontimeuse == false)                                                             //for check only casts once
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().LevelCleared();          //go to next level
                ontimeuse = true;                                                               //if its casted once, make it cant be cast again
            }
        }
    }

    private void StartGrapple()
    {

        Vector3 MousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position);         //gets the mouse position in the world
        MousePos.z = 0;
        Rotating = true;                                                                                        //sets the player in rotation mode


        RaycastHit2D hit = Physics2D.Raycast(transform.position, MousePos.normalized, 4f, Layer);               //makes a raycast to check if from the player to the mouse position there is a grappable block
        if (hit)
        {
            if (hit.transform.position.y < transform.position.y)
            {
                if(Rigid.velocity.y < 1.5)
                {
                    if (transform.position.x < hit.transform.position.x+ 2)
                    {
                        rotationSpeed = 20 * (Rigid.velocity.y * Rigid.velocity.x) / 2;
                    }
                    else { rotationSpeed = -20 * (Rigid.velocity.y * Rigid.velocity.x) / 2; }    //rotate to down
                }
                else
                {
                    rotationSpeed = -20 * (Rigid.velocity.y * Rigid.velocity.x)/2;  //rotate to up
                }
            }
            else
            {
                //if(Rigid)
            }

            //rotationSpeed = (Rigid.velocity.x + Rigid.velocity.y) * -12 ;
            playerState = PlayerState.Rotating;/*
            if (hit.transform.position.y < this.transform.position.y)                              //if the object position is lower than the player one
            {
                if(hit.transform.position.x < this.transform.position.x)
                {
                    if (Rigid.velocity.x > 0) 
                    {
                        rotationSpeed = Rigid.velocity.x * -20;
                    }

                    else if(Rigid.velocity.y <0)
                    {
                        rotationSpeed = Rigid.velocity.y * 20;
                    }

                    else if (Rigid.velocity.y > 0)
                    {
                        rotationSpeed = Rigid.velocity.y * 20;
                    }
                    else 
                    {
                        rotationSpeed = Rigid.velocity.x * -20;
                    }
                }

               else if (hit.transform.position.x > this.transform.position.x)
                {
                    if (Rigid.velocity.x > 0 && (Rigid.velocity.x*-1) < Rigid.velocity.y)
                    {
                        rotationSpeed = Rigid.velocity.x * -20;
                    }

                    else if (Rigid.velocity.y < 0)
                    {
                        rotationSpeed = Rigid.velocity.y * -20;
                    }

                    else if (Rigid.velocity.y > 0)
                    {
                        rotationSpeed = Rigid.velocity.y * -20;
                    }
                    else 
                    {
                        rotationSpeed = Rigid.velocity.x * -20;
                    }
                }
            }
            else
            {
                if (hit.transform.position.x < this.transform.position.x)
                {
                    if (Rigid.velocity.x > 0)
                    {
                        rotationSpeed = Rigid.velocity.x * 20;
                        Debug.Log("1");
                    }

                    else if (Rigid.velocity.y > 0)
                    {
                        rotationSpeed = Rigid.velocity.y * -20;
                        Debug.Log("2");
                    }

                    else if (Rigid.velocity.y < 0)
                    {
                        rotationSpeed = Rigid.velocity.y * 20;
                        Debug.Log("3");
                    }
                    else 
                    {
                        rotationSpeed = Rigid.velocity.x * -20;
                        Debug.Log("4");
                    }
                }

                else if (hit.transform.position.x > this.transform.position.x)
                {
                    if (Rigid.velocity.x > 0 && (Rigid.velocity.x * -1) > Rigid.velocity.y)
                    {
                        rotationSpeed = Rigid.velocity.x * 20;
                        Debug.Log("5");
                    }

                    else if (Rigid.velocity.y < 0)
                    {
                        rotationSpeed = Rigid.velocity.y * -20;
                        Debug.Log("6");
                    }

                    else if (Rigid.velocity.y > 0)
                    {
                        rotationSpeed = Rigid.velocity.x * 20;
                        Debug.Log("7");
                    }
                    else 
                    {
                        rotationSpeed = Rigid.velocity.x * 20;
                        Debug.Log("8");
                    }
                }
            }

            /*if (Rigid.velocity.x > Rigid.velocity.y)
               {
                   rotationSpeed = Rigid.velocity.x * -20;
               }
               else
               {

                   rotationSpeed = Rigid.velocity.y * 20;
               }*/

            
            radius = Mathf.Sqrt((this.transform.position.x + hit.transform.position.x) + (this.transform.position.y + hit.transform.position.y));
            if(radius < 0)
            {
                radius *= -1;
            }
            Rigid.gravityScale = 0;     
            ActualSpeed = Rigid.velocity;                                                     // save the actual speed
            Rigid.velocity = new Vector2(0, 0);                                               //sets speed to 0

            centre = hit.transform;

        }
        else { playerState = PlayerState.Moving; }

    }
    private void EndGrapple()    {   
        Rigid.gravityScale = 4;                                     //gets back the gravity
                                                                    //this.gameObject.transform.parent = null;                        //makes no parent of this object

        //checks the speed before grappling
        if (ActualSpeed.y < 0)                                 
        {
            ActualSpeed.y *= -1;                                //if y speed its negative make it positive for make it jump
        }
        if (ActualSpeed.y > 8)                              // if x speed its more than 8, make it 8 for not to make it go flying
        {
            ActualSpeed.y = 8;
        }
        if (Rotating == true)                               //checks if its rotating
        {
            Rigid.AddForce(new Vector2(ActualSpeed.x * 80, ActualSpeed.y * 80));            //adds the force before jumping to the player so can jump
        }
        Rotating = false;                                                               //resets rotating bool
        playerState = PlayerState.Moving;
        //Destroy(GameObject.Find("Parent(Clone)"));                                                              //destroy the parent
    }

    public void JumpPadForce(float rotationForce, float JumpForceVertical, float jumpForceHorizontal)       //for jumpads
    {
        Rigid.MoveRotation(rotationForce);                                                              //applies the rotation force
        Rigid.AddForce(new Vector2(JumpForceVertical, jumpForceHorizontal));                       //applies the vertical and horizontal force
    }
}

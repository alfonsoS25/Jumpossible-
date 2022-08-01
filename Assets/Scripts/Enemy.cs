using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet = null;                       //bullet 

    public float speed = 5f;                                //rotation speed
    public Transform target;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(shoot_());

    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player(Clone)").transform;                                    //find the Player
        Vector2 direction = target.position - transform.position;                                    //get the distance between player and this game object
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;                         
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);                                    //gets the rotation needed
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);            //rotate towards the player
    }

    private IEnumerator shoot_()
    {
        yield return new WaitForSeconds(2);                                      //Shoot every two seconds
        Instantiate(Bullet, transform.position, transform.rotation);
        StartCoroutine(shoot_());
    }
}

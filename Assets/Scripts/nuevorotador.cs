using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuevorotador : MonoBehaviour
{
    public GameObject orb;
    public float radius;
    public float radiusSpeed;
    public float rotationSpeed;

    private Transform centre;
    private Vector3 desiredPos;

    void Start()
    {
        centre = orb.transform;
        transform.position = (transform.position - centre.position).normalized * radius + centre.position;
    }

    void Update()
    {
        transform.RotateAround(centre.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        desiredPos = (transform.position - centre.position).normalized * radius + centre.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPos, radiusSpeed * Time.deltaTime);
    }
}

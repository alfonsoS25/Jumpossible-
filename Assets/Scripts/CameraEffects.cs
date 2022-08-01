using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void shake()
    {
        StartCoroutine(ShakeEffect());              //Start the shake effect
    }
    public IEnumerator ShakeEffect()
    {
                                                                //move the camera to determinated places
        transform.Translate(0.05f, 0.06f, 0);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(-0.06f, -0.04f, 0);

        yield return new WaitForSeconds(0.1f);

        transform.Translate(+0.06f, +0.06f, 0);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(0.04f, -0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(0, 0, -10);
    }
}

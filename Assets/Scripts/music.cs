using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    static float musicTime = 0;
    [SerializeField]
    private AudioSource audio_;
    void Start()
    {
        audio_ = GetComponent<AudioSource>();               //get the component of the audio
        audio_.time = musicTime;                            //start the music at the point it lefted
    }

    // Update is called once per frame
    void Update()
    {
        musicTime += Time.deltaTime;                        //Add up game secods
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButtonToStart : MonoBehaviour
{
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            StartCoroutine(OnPressButton());                    //starts the courtine
        }
    }

    private IEnumerator OnPressButton()
    {
        Anim.SetTrigger("Start");                               //starts the animation
        yield return new WaitForSeconds(2);                               //wait for 2 seconds
        SceneManager.LoadScene("MainMenu");                               //loads the menu scene
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] buttons = null;
    public int buttonIndex = 0;


    [SerializeField]
    private GameObject gamemanager = null;



    private void Start()
    {
        gamemanager = GameObject.Find("GameManager");
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))                //if key A is pressed
        {
            if(buttonIndex > 0)
            {
                buttonIndex--;                //rest 1 to the selected level
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))                //if key D is pressed
        {
            if(buttonIndex < 11)
            {
                buttonIndex++;                //sums 1 to the selected level
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))                //if key S is pressed
        {
            if (buttonIndex + 4 <= 11)
            {
                buttonIndex+=4;                //sums 4 to the level selected
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))                //if key w is pressed
        {
            if (buttonIndex - 4 >= 0)
            {
                buttonIndex-=4;                //rest 4 to the level selected
            }
        }



        if (Input.GetButtonDown("Submit"))                                  //if key sumbit is pressed
        {
            gamemanager.GetComponent<GameManager>().InstantiateLevel(buttonIndex);                //tell the game manager to instantiathe the selected level
            SceneManager.LoadScene("Main");                                                     //loads the main scene

        }
        for (int index = 0; index < buttons.Length; index++)                                 //makes the selected level a little bigger than the others
        {
            if (index == buttonIndex)
            {
                buttons[index].localScale = new Vector3(1, 1, 1);  
            }
            else
            {
                buttons[index].localScale = new Vector3(0.95f, 0.95f, 1);                                       //if key A is pressed
            }
        }
    }
}




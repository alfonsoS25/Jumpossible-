using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{

    [SerializeField]
    private Transform transformer = null;          //get the canvas transform

    [SerializeField]
    private RectTransform[] buttons = null;

    [SerializeField]
    private GameObject LevelSelector = null;

    public int buttonIndex = 0;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))                                    //if key W is pressed
        {
            if(buttonIndex > 0)
            {
                buttonIndex--;                                                   //rest 1 to the selected level
            }

        }
        else if (Input.GetKeyDown(KeyCode.S))                              //if key S is pressed
        {
            if(buttonIndex < 1)
            {
                buttonIndex++;                                             //sums 1 to the selected level
            }

        }


        if (Input.GetButtonDown("Submit"))                              //when sumbit its pressed
        {
            switch (buttonIndex)
            {
                case 0:
                    Instantiate(LevelSelector, transform.position, transform.rotation,transformer);
                    Destroy(this.gameObject);                                                                    //instantiate level selector and destroy this object
                    break;
                case 1:
                    Application.Quit();                                                                    //quis this application
                    break;
                
            }
        }
        // ボタンの選択状態を更新
        for (int index = 0; index < buttons.Length; index++)
        {
            // 選択状態
            if (index == buttonIndex)
            {
                buttons[index].localScale = new Vector3(1, 1, 1);
            }
            // 非選択状態
            else
            {
                buttons[index].localScale = new Vector3(0.95f, 0.95f, 1);
            }
        }
    }
}




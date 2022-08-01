using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update

        [SerializeField]
        private Transform transformer = null;

        [SerializeField]
        private RectTransform[] buttons = null;


        public int buttonIndex = 0;

    void Start()
    {
        Time.timeScale = 0;                                     //freeze the game
        transformer = GameObject.Find("Canvas").transform;                          //get the transform of the canvas 
        this.transform.parent = transformer;
        transform.position = transformer.position;                          //make same position and transform than the canvas
    }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                //ButtonSound.Play();
                if (buttonIndex > 0)
                {                                                       //when press W, lower button index
                    buttonIndex--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                // ButtonSound.Play();
                if (buttonIndex < 2)
            {                                                       //when press S, upper button index
                buttonIndex++;
                }
            }


            if (Input.GetButtonDown("Submit"))
            {                                                   //when press enter, select the buttonIndex
            switch (buttonIndex)
                {
                    case 0:                                                   //in case 0, resume the game
                    Destroy(this.gameObject);
                    GameObject.Find("GameManager").GetComponent<GameManager>().IsPause = false;
                    Time.timeScale = 1;
                        break;
                    case 1:                                                   //in case 1, return to menu
                    ReturnToMainMenu();
                        break;
                    case 2:                                                   //in case 2, exit the application
                    Application.Quit();
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

        public void ReturnToGame()
        {
            SceneManager.LoadScene("main");                                                                    //return to main game
    }
        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");                                                                 //return to main menu
    }
    }


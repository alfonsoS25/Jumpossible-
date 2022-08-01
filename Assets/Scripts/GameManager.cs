using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsPause = false;

    [SerializeField]
    private bool onMenu = false;

    [SerializeField]
    private GameObject Player = null;

    [SerializeField]
    private GameObject Pause = null;

    static int stageNo = 0;


    static float timeRecord0= 10;
    static float timeRecord1 = 10;
    static float timeRecord2 = 10;
    static float timeRecord3 = 10;
    static float timeRecord4 = 10;
    static float timeRecord5 = 10;
    static float timeRecord6 = 10;
    static float timeRecord7 = 10;
    static float timeRecord8 = 10;
    static float timeRecord9 = 10;
    static float timeRecord10 = 10;
    static float timeRecord11 = 10;

    float timerForRecords = 0;

    [SerializeField]
    private Text StageTimer = null;

    [SerializeField]
    private Text Record = null;

    private float recordFloat = 110;
    void Start()
    {
        Time.timeScale = 1;
        if (onMenu == false)
        {
            SelectRecord();                                                                            //gets the record for the stage
            Record.text = "Best Time: " + recordFloat.ToString("F2");                                  //writes in UI text the record of the level
            GeneratePlayer();
            var prefabName = string.Format("stage{0}", stageNo);
            var stagePrefab = Resources.Load<GameObject>(prefabName);                                   //instantiate the stage
            Instantiate(stagePrefab, transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (onMenu == false)                                    
        {
            StageTimer.text = "Time :" + timerForRecords.ToString("F2");                            //shows the time Playing
            if (IsPause == false)
            {
                timerForRecords += Time.deltaTime;                                                  //Sums the time to the float
            }

            if (Input.GetKeyDown(KeyCode.Escape) && IsPause == false)
            {
                Instantiate(Pause);                                                                 //instantiate the pause menu
                IsPause = true;                                                                     //sets the game in pause
            }
        }
    }

    public void InstantiateLevel(int SetLevelToInstantiate)
    {
        stageNo = SetLevelToInstantiate;                                //instantiate the level selected
    }
    public void LevelCleared()                              //called when the level is clear
    {
        if (timerForRecords < recordFloat)
        {
            saveRecord();                                   //save the record
        }
        stageNo++;                                          //sums 1 to the level to load
        if (stageNo > 11)
        {
            SceneManager.LoadScene("LevelCleared");         //if level is over 11, loads the game plear scene
        }
        else
        {
            SceneManager.LoadScene("Main");                 // else, reload the scene with the new level
        }
    }
    public void GeneratePlayer()                            //Instantiates a player when starts scenes and player dies
    {
        Instantiate(Player, new Vector3(-5.65f, -2f, 1), transform.rotation);
    }

    void saveRecord()
    {                                               // saves the record on a static for not delete
        switch (stageNo)              
        {
            case 0:
                timeRecord0 = timerForRecords;
                break;
            case 1:
                timeRecord1 = timerForRecords; break;
            case 2:
                timeRecord2 = timerForRecords; break;
            case 3:
                timeRecord3 = timerForRecords; break;
            case 4:
                timeRecord4 = timerForRecords; break;
            case 5:
                timeRecord5 = timerForRecords; break;
            case 6:
                timeRecord6 = timerForRecords; break;
            case 7:
                timeRecord7 = timerForRecords; break;
            case 8:
                timeRecord8 = timerForRecords; break;
            case 9:
                timeRecord9 = timerForRecords; break;
            case 10:
                timeRecord10 = timerForRecords; break;
            case 11:
                timeRecord11 = timerForRecords; break;
        }
    }
    void SelectRecord()
    {                                               //detects what stage the player is and loads the record of the level

        switch (stageNo)
        {
            case 0:
                recordFloat = timeRecord0;
                break;
            case 1:
                recordFloat = timeRecord1;
                break;
            case 2:
                recordFloat = timeRecord2;
                break;
            case 3:
                recordFloat = timeRecord3;
                break;
            case 4:
                recordFloat = timeRecord4;
                break;
            case 5:
                recordFloat = timeRecord5;
                break;
            case 6:
                recordFloat = timeRecord6;
                break;
            case 7:
                recordFloat = timeRecord7;
                break;
            case 8:
                recordFloat = timeRecord8;
                break;
            case 9:
                recordFloat = timeRecord9;
                break;
            case 10:
                recordFloat = timeRecord10;
                break;
            case 11:
                recordFloat = timeRecord11;
                break;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Timer of level
    private TimeManager _TimeManager;

    //GamePlay
    private GamePlay _GamePlay;

    //End of Level Panel
    public GameObject EndOfLevelUIPanel;

    // Start is called before the first frame update
    void Start()
    {
        _TimeManager = GetComponent<TimeManager>();
        _GamePlay = GetComponent<GamePlay>();

        //Hide end panel
        EndPanelUI_Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void CheckAnimalsInGroups ()
    //{

    //}

    public void TimeIsOver ()
    {
        //Check if animal left
        //yes: lose
        if (_GamePlay.CheckifAnimalLeft()) { print("You lost!"); }
       
        //No: Win
        else { print("You Won!"); }

        //Show panel
        EndPanelUI_Activate();

        //Pause the game
        Game_Pause();
        //Time.timeScale = 0;


    }

    public void EndPanelUI_Activate()
    {
        EndOfLevelUIPanel.SetActive(true);
    }

    public void EndPanelUI_Deactivate()
    {
        EndOfLevelUIPanel.SetActive(false);
    }


    public void EndPanelUI_BtnReplay ()
    {
        //Reload the current scene
    }

    public void EndPanelUI_BtnHome ()
    {
        //Go to Home scene (Menu)
    }

    private void Game_Pause ()
    {

    }

    private void Game_Continue ()
    {

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Timer of level
    private TimeManager _TimeManager;

    //GamePlay
    private GamePlay _GamePlay;

    // Start is called before the first frame update
    void Start()
    {
        _TimeManager = GetComponent<TimeManager>();
        _GamePlay = GetComponent<GamePlay>();
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

        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float LevelTime = 60f;
    public float remainingTime=0;
    public bool isGameLost = false;
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        //set Time text
        timeText.text = "Time: " + remainingTime.ToString();
    }

    private IEnumerator Timer ()
    {
        remainingTime = LevelTime;
        //float _time = time;
        while (remainingTime > 0 )
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        //if ( !isGameLost ) {

        //check if animals are left or not
        //Game Manager
        GetComponentInParent<GameManager>().TimeIsOver();
        
        
    }

    public void ChangeFire ()
    {
        //
    }

}

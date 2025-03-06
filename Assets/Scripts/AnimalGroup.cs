using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalGroup : MonoBehaviour
{    
    public GamePlay.Direction groupDirection; // Assign Left or Right in the Inspector

    public void SelectAnimal(GameObject selectedAnimal)
    {
        print("select animal: " + selectedAnimal.name+" direction: " + groupDirection);
        GamePlay.Instance.SetAnimal(selectedAnimal, groupDirection);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalGroup : MonoBehaviour
{    
    public GamePlay.Direction groupDirection; // Assign Left or Right in the Inspector

    //My slots and their status
    public List<AnimalSlot> mySlots;

    //Code to test
    public List<GameObject> testAnimal;
    
    // Start is called before the first frame update
    void Start()
    {
        //Code to test
        foreach(GameObject _gameObject in testAnimal) { AddAnimal(_gameObject); }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Sending Selected animal to game manager and recieve former if there is any

    //placing animal in slots
    public void AddAnimal(GameObject animal)
    {
        foreach (AnimalSlot slot in mySlots)
        {
            if (slot.myAnimal == null)
            {
                slot.AssignAnimal(animal);
                animal.transform.parent = transform;
                animal.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                return;
            }
        }
        print("No place to add animal to " + this.gameObject.name);
    }

    public GameObject HandOverAnimal(GameObject animal)
    {
        // Empty including slot
        foreach (AnimalSlot slot in mySlots)
        {
            if (slot.myAnimal == animal)
            {
                slot.RemoveAnimal();
                //Handover to GameManager
                return GamePlay.Instance.TransferAnimals(animal, groupDirection);
                //return;
            }
        }

        //selected item does not belong to this group
        return null;
        

    }

    public void SelectAnimal(GameObject selectedAnimal)
    {
        print("select animal: " + selectedAnimal.name + " direction: " + groupDirection);
        GameObject _result = HandOverAnimal(selectedAnimal);
        if (_result != null) { AddAnimal(_result); }
    }

    public void ReturnAnimal(GameObject animal)
    {
        GamePlay.Instance.ClearAnimal(animal);
        AddAnimal(animal);
    }

    public bool IsAnimalLeft ()
    {
        foreach (AnimalSlot slot in mySlots)
        {
            if (slot.myAnimal != null)
            {
                return true;
            }
        }
        return false;
    }
}

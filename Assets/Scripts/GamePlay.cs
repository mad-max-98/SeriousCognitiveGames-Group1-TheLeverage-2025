using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public static GamePlay Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of GamePlay detected! Destroying duplicate.");
            Destroy(gameObject);
            return;
        }
    }

    public TextMeshProUGUI DirectionText;
    public enum Direction
    {
        Left, Right 
    }

    public Direction currentDirection = Direction.Right;
    //AnimalGroups
    public AnimalGroup LeftSideAnimalGroup;
    public AnimalGroup RightSideAnimalGroup;
    // Active slots
    public AnimalSlot activeLeftSlot;
    public AnimalSlot activeRightSlot;
    // active animals
    //public GameObject currentLeftAnimal;
    //public GameObject currentRightAnimal;
    // Slots 
    public Transform leftUpSlot;
    public Transform rightUpSlot;
    public Transform leftDownSlot;
    public Transform rightDownSlot;
    //sample animal to test functionality of SetAnimal
    //public GameObject animal_right;
    //public GameObject animal_left;
    //public GameObject animal_right_2;
    // Start is called before the first frame update
    void Start()
    {
        SetDirection();
    }

    // Update is called once per frame
    void Update()
    {
        //currentLeftAnimal = activeLeftSlot.GetChild(0).gameObject;
        //currentRightAnimal = activeRightSlot.GetChild(0).gameObject;

        //sample code to test functionality
        //if (Input.GetKeyDown(KeyCode.W)) { SetAnimal(animal_right, Direction.Right); SetAnimal(animal_left, Direction.Left); }
        if (Input.GetKeyDown(KeyCode.D)) { SetDirection(); }
        //if (Input.GetKeyDown(KeyCode.S)) 
        //{ 
        //    currentLeftAnimal.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //    currentRightAnimal.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    SetAnimal(animal_right_2, Direction.Right);
        //}
    }


    public void SetDirection ()
    {
        
        currentDirection = currentDirection == Direction.Right? Direction.Left:Direction.Right;
        if (currentDirection == Direction.Left)
        {
            activeLeftSlot.transform.position = leftUpSlot.transform.position;
            activeRightSlot.transform.position = rightDownSlot.transform.position;
        }
        else if (currentDirection == Direction.Right) {
            activeLeftSlot.transform.position = leftDownSlot.transform.position;
            activeRightSlot.transform.position = rightUpSlot.transform.position;
        }
        DirectionText.text = currentDirection.ToString(); 

    }

    //This function is called by Left side animal group
    private GameObject TransferLeftAnimals ( GameObject AnimalRecievedFromLeftSide)
    {
        //is there free space for left side animal ?
        if (activeLeftSlot.myAnimal == null)
        {
            //set this newly recievd animal to left active place
            activeLeftSlot.AssignAnimal(AnimalRecievedFromLeftSide);
            return null;

        }
        //already occupiedd by any former animal ?
        else
        {
            GameObject _formerAnimal = activeLeftSlot.RemoveAnimal();
            //set this newly recievd animal to left active place
            activeLeftSlot.AssignAnimal(AnimalRecievedFromLeftSide);

            //return former animal to left side
            return _formerAnimal;
        }
    }

    private GameObject TransferRightAnimals(GameObject AnimalRecievedFromRightSide)
    {
        //is there free space for left side animal ?
        if (activeRightSlot.myAnimal == null)
        {
            //set this newly recievd animal to left active place
            activeRightSlot.AssignAnimal(AnimalRecievedFromRightSide);
            return null;

        }
        //already occupiedd by any former animal ?
        else
        {
            GameObject _formerAnimal = activeRightSlot.RemoveAnimal();
            //set this newly recievd animal to left active place
            activeRightSlot.AssignAnimal(AnimalRecievedFromRightSide);

            //return former animal to left side
            return _formerAnimal;
        }
    }

    public GameObject TransferAnimals (GameObject AnimalRecieved , Direction direction)
    {
        if (direction == Direction.Left) 
            return TransferLeftAnimals( AnimalRecieved );
        //else if (direction == Direction.Right)
        //    return TransferRightAnimals ( AnimalRecieved );
        else
            return TransferRightAnimals(AnimalRecieved);


    }

    public void Play ()
    {
        if (currentDirection == Direction.Left)
        {
            activeRightSlot.ReleaseAnimal();
            activeLeftSlot.ReleaseAnimal();
        } else
        {
            activeLeftSlot.ReleaseAnimal();
            activeRightSlot.ReleaseAnimal();
        }
    } 

    public void ClearScene ()
    {
        //Return right side animal
        RightSideAnimalGroup.AddAnimal(activeRightSlot.myAnimal);
        activeRightSlot.myAnimal = null;


        //Return left side animal
        LeftSideAnimalGroup.AddAnimal(activeLeftSlot.myAnimal);
        activeLeftSlot.myAnimal = null;
    }

    public void ClearAnimal(GameObject animal)
    {
        if (activeLeftSlot.myAnimal == animal) { activeLeftSlot.myAnimal = null; }
        else if (activeRightSlot.myAnimal == animal) { activeRightSlot.myAnimal = null; }
    }


    //public void SetAnimal(GameObject selectedAnimal , Direction direction)
    //{
    //    // if selected animal belongs to left side
    //    if (direction == Direction.Left)
    //    {
    //        if (currentLeftAnimal != null) 
    //        { 
    //            //getting position and parent of selected animal and assign it to currnet left animal
    //            currentLeftAnimal.transform.position = selectedAnimal.transform.position;
    //            currentLeftAnimal.transform.parent = selectedAnimal.transform.parent;
    //            currentLeftAnimal.transform.rotation = activeLeftSlot.transform.rotation;
    //            //make it static
    //            //currentLeftAnimal.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    //        }

    //        //make selected animal under the left slot
    //        selectedAnimal.transform.SetParent(activeLeftSlot);
    //        selectedAnimal.transform.position = activeLeftSlot.transform.position;
    //        selectedAnimal.transform.rotation = activeLeftSlot.transform.rotation;
    //        // make it active jumping thing
    //        //selectedAnimal.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    //        currentLeftAnimal = selectedAnimal;
    //    }

    //    // if selected animal belongs to right side
    //    if (direction == Direction.Right)
    //    {
    //        if (currentRightAnimal != null)
    //        {
    //            //getting position and parent of selected animal and assign it to currnet right animal
    //            currentRightAnimal.transform.position = selectedAnimal.transform.position;
    //            currentRightAnimal.transform.parent = selectedAnimal.transform.parent;
    //            currentRightAnimal.transform.rotation = activeRightSlot.transform.rotation;
    //            //make it static
    //            currentRightAnimal.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    //        }

    //        //make selected animal under the left slot
    //        selectedAnimal.transform.SetParent(activeRightSlot);
    //        selectedAnimal.transform.position = activeRightSlot.transform.position;
    //        selectedAnimal.transform.rotation = activeRightSlot.transform.rotation;
    //        // make it active jumping thing
    //        selectedAnimal.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    //        currentRightAnimal = selectedAnimal;
    //    }


    //}
}

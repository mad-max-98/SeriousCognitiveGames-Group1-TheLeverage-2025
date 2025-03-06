using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    //Singleton (to be completed)
    public static GamePlay Instance;
    public enum Direction
    {
        Left, Right 
    }

    public Direction currentDirection = Direction.Right;
    // Active slots
    public Transform activeLeftSlot;
    public Transform activeRightSlot;
    // active animals
    public GameObject currentLeftAnimal;
    public GameObject currentRightAnimal;
    // Slots 
    public Transform leftUpSlot;
    public Transform rightUpSlot;
    public Transform leftDownSlot;
    public Transform rightDownSlot;
    //sample animal to test functionality of SetAnimal
    public GameObject animal_right;
    public GameObject animal_left;
    public GameObject animal_right_2;
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
        if (Input.GetKeyDown(KeyCode.W)) { SetAnimal(animal_right, Direction.Right); SetAnimal(animal_left, Direction.Left); }
        if (Input.GetKeyDown(KeyCode.S)) { SetDirection(); }
        if (Input.GetKeyDown(KeyCode.D)) 
        { 
            currentLeftAnimal.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            currentRightAnimal.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetAnimal(animal_right_2, Direction.Right);
        }
    }


    public void SetDirection ()
    {
        
        currentDirection = currentDirection == Direction.Right? Direction.Left:Direction.Right;
        if (currentDirection == Direction.Left)
        {
            activeLeftSlot = leftUpSlot;
            activeRightSlot = rightDownSlot;
        }
        else if (currentDirection == Direction.Right) {
            activeLeftSlot = leftDownSlot;
            activeRightSlot = rightUpSlot;
        }

    }


    public void SetAnimal(GameObject selectedAnimal , Direction direction)
    {
        // if selected animal belongs to left side
        if (direction == Direction.Left)
        {
            if (currentLeftAnimal != null) 
            { 
                //getting position and parent of selected animal and assign it to currnet left animal
                currentLeftAnimal.transform.position = selectedAnimal.transform.position;
                currentLeftAnimal.transform.parent = selectedAnimal.transform.parent;
                
            }
            
            //make selected animal under the left slot
            selectedAnimal.transform.SetParent(activeLeftSlot);
            selectedAnimal.transform.position = activeLeftSlot.transform.position;
            selectedAnimal.transform.rotation = activeLeftSlot.transform.rotation;
            currentLeftAnimal = selectedAnimal;
        }

        // if selected animal belongs to right side
        if (direction == Direction.Right)
        {
            if (currentRightAnimal != null)
            {
                //getting position and parent of selected animal and assign it to currnet right animal
                currentRightAnimal.transform.position = selectedAnimal.transform.position;
                currentRightAnimal.transform.parent = selectedAnimal.transform.parent;

            }

            //make selected animal under the left slot
            selectedAnimal.transform.SetParent(activeRightSlot);
            selectedAnimal.transform.position = activeRightSlot.transform.position;
            selectedAnimal.transform.rotation = activeRightSlot.transform.rotation;
            currentRightAnimal = selectedAnimal;
        }


    }
}

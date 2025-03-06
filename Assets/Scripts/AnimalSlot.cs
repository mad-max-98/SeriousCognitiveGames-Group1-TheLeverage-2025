using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSlot : MonoBehaviour
{
    public GameObject myAnimal = null; // null means slot is available

    public void AssignAnimal(GameObject animal)
    {
        if (myAnimal)
        {
            Debug.Log("Slot is already occupied!");
        }
        else
        {
            //animal.transform.SetParent(transform);
            animal.transform.position = transform.position;
            animal.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            myAnimal = animal;
            
        }
    }

    public GameObject RemoveAnimal()
    {
        GameObject _animal = myAnimal;
        myAnimal = null;
        return _animal;
    }

    public void ReleaseAnimal()
    {
        if (myAnimal) { myAnimal.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; }
    }
}

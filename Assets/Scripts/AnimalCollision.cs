using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision with baloon
        if (collision.gameObject.CompareTag("Balloon"))
        {
            print("Balloon");
            //Animal is not selectable anymore
            this.gameObject.GetComponent<AnimalSelector>().enabled = false;

            //Add another animal to the group of this animal to fill the place
            GamePlay.Instance.ReplaceMovedAnimal(this.gameObject, GetComponentInParent<AnimalGroup>().groupDirection);

            //move animal to baloon
            transform.SetParent(collision.gameObject.transform);
            
            collision.gameObject.GetComponent<AnimalGroup>().AddAnimal(this.gameObject);

            ScoreManager.Instance.ScoreIncrement();

            //GamePlay.Instance.ClearAnimal(this.gameObject);


            //transform.position = collision.gameObject.transform.position;
            //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }

        // collision with ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            print("Ground");
            //transform.position = GetComponentInParent<AnimalGroup>().transform.position;
            //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponentInParent<AnimalGroup>().ReturnAnimal(this.gameObject);
        }
    }
}

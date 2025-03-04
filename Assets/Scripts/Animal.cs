using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    public AnimalData _animalData;
    private SpriteRenderer _sr;
    private Rigidbody2D _rb;
    private BoxCollider2D _bxc2d;
    // Start is called before the first frame update
    void Start()
    {
        
        //Sprite set
        _sr = GetComponent<SpriteRenderer>();
        //RigidBody2D Set 
        _rb = GetComponent<Rigidbody2D>();
        //BoxCollider2D set
        _bxc2d = GetComponent<BoxCollider2D>();
        //transform set

        ApplyAnimalData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ApplyAnimalData()
    {

        //GameObject's Name set
        gameObject.name = _animalData.name;
        //Sprite set
        _sr.sprite = _animalData.animalSprite;
        //RigidBody2D Set
        _rb.gravityScale = _animalData.animalGravityForce;
        _rb.drag = _animalData.animalLinearDrag;
        _rb.mass = _animalData.animalWeight;
        //BoxCollider2D set
        _bxc2d.size = _animalData.animalDimensions;
        //transform scale set
        //transform.localScale = _animalData.animalDimensions;

    }
}

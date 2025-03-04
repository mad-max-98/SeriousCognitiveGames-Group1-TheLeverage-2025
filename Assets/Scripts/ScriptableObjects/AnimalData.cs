using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Animal Data", menuName ="Animal Data",order = 50)]
public class AnimalData : ScriptableObject
{
    public string animalName;
    [Range(0.1f,5f)] public float animalWeight;
    [Range(1f, 10f)] public float animalGravityForce;
    [Range(0.1f, 2f)] public float animalLinearDrag;
    public Vector2 animalDimensions;
    public Sprite animalSprite;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotTransform : MonoBehaviour
{
    //Leverage
    public HingeJoint2D _joint;
    //magnitude
    public float _magnitude = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position.x = _joint.anchor.x;
        transform.position = Vector3.Lerp( transform.position ,new Vector3(_joint.anchor.x * _magnitude,
            transform.position.y,transform.position.z),
            1f);
    }
}

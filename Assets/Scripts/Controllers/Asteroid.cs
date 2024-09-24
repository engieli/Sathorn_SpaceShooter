using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    private Vector3 targetpoint;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 random direction= 
        currentVelocity = Vector3.MoveTowards(currentVelocity, offset * maxSpeed, acceleration * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if ( Player )
    }
}

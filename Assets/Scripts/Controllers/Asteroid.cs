using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float arrivalDistance = 0.5f;
    public float maxFloatDistance = 5f;

    private Vector3 targetPoint;


    // Start is called before the first frame update
    void Start()
    {
        ChooseRandomPoint();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();

        
        if (Vector3.Distance(transform.position, targetPoint) <= arrivalDistance)
        {
          
            ChooseRandomPoint();
        }
    }

    void ChooseRandomPoint()
    {
       
        Vector3 randomDirection = Random.insideUnitSphere; 
        randomDirection.z = 0;  
        targetPoint = transform.position + randomDirection * Random.Range(0f, maxFloatDistance);
    }

    
    void MoveTowardsTarget()
    {
       
        Vector3 direction = (targetPoint - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

}

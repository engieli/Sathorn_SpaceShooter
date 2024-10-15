using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float arrivalDistance = 0.5f;
    public float maxFloatDistance = 5f;

    private Vector3 targetPoint;

    public Transform moonTransform; 
    public float moonDetectionRadius = 5f;
    public float orbitSpeed = 30f;
    private bool isInOrbit = false;
    public float orbitRadius = 2f;
    private float currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        ChooseRandomPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (moonTransform != null)
        {
            if (isInOrbit)
            {
                RotateAroundMoon();
            }
            else
            {
                CheckForOrbit();
                MoveTowardsTarget();
            }
        }

        if (!isInOrbit && Vector3.Distance(transform.position, targetPoint) <= arrivalDistance)
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

    private void RotateAroundMoon()
    {
        currentAngle += orbitSpeed * Time.deltaTime;

        float x = moonTransform.position.x + orbitRadius * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = moonTransform.position.y + orbitRadius * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        transform.position = new Vector3(x, y, transform.position.z);
    }


    private void CheckForOrbit()
    {
      
        float distanceToMoon = Vector3.Distance(transform.position, moonTransform.position);


        if (distanceToMoon <= moonDetectionRadius)
        {
            isInOrbit = true;
            Vector3 direction = transform.position - moonTransform.position;
            currentAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
    }

}

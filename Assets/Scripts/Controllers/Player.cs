using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float maxSpeed = 5f;
    public float accelerationTime = 2f;
    private float acceleration;
    private Vector3 currentVelocity = Vector3.zero;

    public float radarRadius = 5f;
    public int circlePoints = 20;

    public GameObject powerupPrefab;

    public List<Transform> debrisTransforms;
    public float detectionRadius = 5f; 
    public float moveAroundSpeed = 3f; 


    void Start()
    {

        acceleration = maxSpeed / accelerationTime;
    }

    void Update()
    {


        Vector3 offset = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))

            offset += Vector3.left;

        if (Input.GetKey(KeyCode.RightArrow))

            offset += Vector3.right;

        if (Input.GetKey(KeyCode.UpArrow))

            offset += Vector3.up;

        if (Input.GetKey(KeyCode.DownArrow))

            offset += Vector3.down;



        offset = offset.normalized;



        if (offset != Vector3.zero)

        {
            currentVelocity = Vector3.MoveTowards(currentVelocity, offset * maxSpeed, acceleration * Time.deltaTime);
        }

        else
        {

            currentVelocity = Vector3.MoveTowards(currentVelocity, Vector3.zero, acceleration * Time.deltaTime);
        }


        if (!CheckObjectProximityAndMoveAround())
        {
            if (offset != Vector3.zero)
            {
                currentVelocity = Vector3.MoveTowards(currentVelocity, offset * maxSpeed, acceleration * Time.deltaTime);
            }
            else
            {
                currentVelocity = Vector3.MoveTowards(currentVelocity, Vector3.zero, acceleration * Time.deltaTime);
            }

            transform.position += currentVelocity * Time.deltaTime;
        }



        EnemyRadar();

        if (Input.GetKeyDown(KeyCode.P))
        {  
            SpawnPowerups(3f, 5); 
        }
    }

    private void EnemyRadar()
    {

        float enemyDistance = Vector3.Distance(transform.position, enemyTransform.position);

        Color circleColor = (enemyDistance < radarRadius)? Color.red : Color.green;

        float angleStep = 360f / circlePoints;

        Vector3 previousPoint = transform.position + new Vector3(Mathf.Cos(0), Mathf.Sin(0), 0) * radarRadius;

        for (int i = 1; i <= circlePoints; i++)
        {

            float angleInRadians = Mathf.Deg2Rad * (i * angleStep);
            float xPos = Mathf.Cos(angleInRadians) * radarRadius;
            float yPos = Mathf.Sin(angleInRadians) * radarRadius;
            Vector3 currentPoint = transform.position + new Vector3(xPos, yPos, 0f);
            Debug.DrawLine(previousPoint, currentPoint, circleColor);
            previousPoint = currentPoint;
        }
    }

    private bool CheckObjectProximityAndMoveAround()
    {
        foreach (Transform objTransform in debrisTransforms) 
        {
            float distanceToObject = Vector3.Distance(transform.position, objTransform.position);

            if (distanceToObject <= detectionRadius)
            {
               
                Vector3 directionToObject = (objTransform.position - transform.position).normalized;
                Vector3 perpendicularDirection = Vector3.Cross(directionToObject, Vector3.forward).normalized;

               
                transform.position += perpendicularDirection * moveAroundSpeed * Time.deltaTime;
                return true; 
            }
        }

        return false;  
    }

    private void PlayerMovement(Vector3 offset)
    {
        transform.position += offset;
    }
    public void SpawnPowerups(float radarRadius, int numberOfPowerups)
    {
        float angleStep = 360f / numberOfPowerups;

        for (int i = 0; i < numberOfPowerups; i++)
        {
            float angleInDegrees = i * angleStep;
            float angleInRadians = Mathf.Deg2Rad * angleInDegrees;

            float xPos = transform.position.x + Mathf.Cos(angleInRadians) * radarRadius;
            float yPos = transform.position.y + Mathf.Sin(angleInRadians) * radarRadius;
            Vector3 spawnPosition = new Vector3(xPos, yPos, transform.position.z);

            Instantiate(powerupPrefab, spawnPosition, Quaternion.identity);
        }

    }

}

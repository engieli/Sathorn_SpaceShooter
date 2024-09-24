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


    // public Vector3 velocity = new Vector3(1f, 0f);
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


       //PlayerMovement(offset);
        offset = offset.normalized; 

       // inputDirection = inputDirection.normalized;

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

    private void PlayerMovement(Vector3 offset)
    {
        transform.position += offset;
    }
}



// Task 1

//transform.position = transform.position + velocity;
//if (Input.GetKeyDown(KeyCode.LeftArrow))
//{
//    transform.position = new Vector3(transform.position.x - 1f, transform.position.y);
//}
//if (Input.GetKeyDown(KeyCode.RightArrow))
//{
//    transform.position = new Vector3(transform.position.x + 1f, transform.position.y);
//}
//if (Input.GetKeyDown(KeyCode.UpArrow))
//{
//    transform.position = new Vector3(transform.position.x + transform.position.z , +1f);
//}
//if (Input.GetKeyDown(KeyCode.DownArrow))
//{
//    transform.position = new Vector3(transform.position.x + transform.position.z, -1f);
//}

//Vector3 offset = Vector3.zero;

//if (Input.GetKey(KeyCode.LeftArrow))

//    offset += Vector3.left * 0.01f;

//if (Input.GetKey(KeyCode.RightArrow))

//    offset += Vector3.right * 0.01f;

//if (Input.GetKey(KeyCode.UpArrow))

//    offset += Vector3.up * 0.01f;

//if (Input.GetKey(KeyCode.DownArrow))

//    offset += Vector3.down * 0.01f;


//PlayerMovement(offset);


//Task 2
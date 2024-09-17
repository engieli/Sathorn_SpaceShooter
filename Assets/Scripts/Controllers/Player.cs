using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

   // public Vector3 velocity = new Vector3(1f, 0f);

    
    void Update()
    {
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

        Vector3 offset = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        
            offset += Vector3.left * 0.01f;
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        
            offset += Vector3.right * 0.01f;
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        
            offset += Vector3.up * 0.01f;
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        
            offset += Vector3.down * 0.01f;
        

    }
    private void PlayerMovement(Vector3 offset)
    {
        transform.position += offset;

    }
}

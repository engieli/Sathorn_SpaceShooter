using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    private float angle = 0f;

   
    public void OrbitalMotion(float radius, float speed, Transform target)
    { 
        angle += speed * Time.deltaTime;

      
        float angleInRadians = Mathf.Deg2Rad * angle;
        float xPos = target.position.x + Mathf.Cos(angleInRadians) * radius;
        float yPos = target.position.y + Mathf.Sin(angleInRadians) * radius;
        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }

    void Update()
    {
        OrbitalMotion(5f, 50f, target: planetTransform);
    }
}

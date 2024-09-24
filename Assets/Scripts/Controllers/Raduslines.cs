using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Raduslines : MonoBehaviour
{
    public List<float> angles;
    private void OnValidate()
    {
        
    }
    void Start()
    {
        if (angles == null) angles = new List<float>();
        for (int i = 0; i < 10; i++)
        {
            angles.Add(Random.value * 360);

        }
        transform.position += RectOffset;

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime

        float xPos = Mathf.Cos(radians);
        float yPos = Mathf.Sin(radians);

        Vector3 endPoint =new Vector3 (xPos, yPos, 0f)

    }
}

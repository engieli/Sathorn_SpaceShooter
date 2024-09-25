using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    private LineRenderer lineRenderer;
    private int currentStarIndex = 0;

    // Update is called once per frame
    void Update()
    {
    }
    void Start()
    {
        
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

       

    StartCoroutine(DrawLinesBetweenStars());
    }

    
    IEnumerator DrawLinesBetweenStars()
    {
        while (true)
        {
            
            int nextStarIndex = (currentStarIndex + 1) % starTransforms.Count;

            
            Vector3 startPoint = starTransforms[currentStarIndex].position;
            Vector3 endPoint = starTransforms[nextStarIndex].position;

            for (float t = 0; t < drawingTime; t += Time.deltaTime)
            {
                float progress = t / drawingTime;
                Vector3 currentPoint = Vector3.Lerp(startPoint, endPoint, progress);

                
                lineRenderer.SetPosition(0, startPoint);
                lineRenderer.SetPosition(1, currentPoint);

                yield return null; 
            }

            
            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, endPoint);

           
            currentStarIndex = nextStarIndex;

           
            yield return null;
        }
    }
}

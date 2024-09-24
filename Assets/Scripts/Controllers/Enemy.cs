using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject enemyPrefab;  
    public float spawnInterval = 5f;  
    public float initialSpeed = 2f;  
    public float acceleration = 1f; 
    public Vector3 movementDirection = Vector3.forward;

    private float currentSpeed;
    private float timeSinceLastSpawn;

    void Start()
    {
        currentSpeed = initialSpeed;
        timeSinceLastSpawn = 0f;
    }

    void Update()
    {
     
        timeSinceLastSpawn += Time.deltaTime;

        
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f; 
        }

        
        currentSpeed += acceleration * Time.deltaTime;
        transform.Translate(movementDirection * currentSpeed * Time.deltaTime);
    }

    void SpawnEnemy()
    {
       
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
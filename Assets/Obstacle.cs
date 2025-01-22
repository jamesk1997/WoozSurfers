using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed; // Speed at which the obstacle moves
    private float destroyY; // Y position where the obstacle is destroyed

    public void Initialize(float obstacleSpeed, float destroyYPosition)
    {
        speed = obstacleSpeed;
        destroyY = destroyYPosition;
    }

    void Update()
    {
        // Move the obstacle downward
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Destroy the obstacle if it goes below the screen
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }
}

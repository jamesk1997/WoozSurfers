using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f; // Speed for smooth movement between lanes

    private int currentLane = 1; // 0 = Left, 1 = Center, 2 = Right
    private readonly float[] lanes = { -3f, 0f, 3f }; // X positions for the lanes
    private bool isSwitchingLane = false; // Prevent switching during animation

    void Update()
    {
        HandleLaneSwitching();
    }

    void HandleLaneSwitching()
    {
        // Move Left
        if (Input.GetKeyDown(KeyCode.A) && currentLane > 0 && !isSwitchingLane)
        {
            currentLane--;
            MoveToLane();
        }

        // Move Right
        if (Input.GetKeyDown(KeyCode.D) && currentLane < lanes.Length - 1 && !isSwitchingLane)
        {
            currentLane++;
            MoveToLane();
        }
    }

    void MoveToLane()
    {
        isSwitchingLane = true; // Prevent further lane switching
        Vector3 targetPosition = new Vector3(lanes[currentLane], transform.position.y, transform.position.z);
        StartCoroutine(SmoothMove(targetPosition));
    }

    System.Collections.IEnumerator SmoothMove(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Snap to the final position and reset the flag
        transform.position = targetPosition;
        isSwitchingLane = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something collided with the player!");
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("Hit! Player collided with an obstacle.");
        }
    }

}

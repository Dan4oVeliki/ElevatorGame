using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorslide : MonoBehaviour
{
    public Transform doorTransform;
    public Vector3 closedPosition;
    public Vector3 openPosition;
    public float doorSpeed = 2.0f;

    private bool isOpen = false;  // Track if the door is open or closed
    private bool isMoving = false;  // Prevent triggering if already moving

    // Public getter for the door state (open or closed)
    public bool IsOpen { get { return isOpen; } }

    // Method to open the door
    public void OpenDoor()
    {
        if (!isMoving && !isOpen)
        {
            isMoving = true;
            StartCoroutine(MoveDoor(openPosition));
        }
    }

    // Method to close the door
    public void CloseDoor()
    {
        if (!isMoving && isOpen)
        {
            isMoving = true;
            StartCoroutine(MoveDoor(closedPosition));
        }
    }

    // Coroutine to smoothly move the door to the target position
    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (Vector3.Distance(doorTransform.position, targetPosition) > 0.1f)
        {
            doorTransform.position = Vector3.Lerp(doorTransform.position, targetPosition, Time.deltaTime * doorSpeed);
            yield return null;
        }
        doorTransform.position = targetPosition; // Ensure exact position

        // Update the door's state and stop the movement
        isOpen = targetPosition == openPosition;
        isMoving = false;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentDoor : MonoBehaviour
{
    public doorslide door1;
    public doorslide door2;

    // Trigger the doors to open if both are closed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  // Press "E" to open
        {
            TriggerOpen();
        }

        if (Input.GetKeyDown(KeyCode.C))  // Press "C" to close
        {
            TriggerClose();
        }
    }
    public void TriggerOpen()
    {
        if (!door1.IsOpen && !door2.IsOpen)  // Only open if both doors are closed
        {
            door1.OpenDoor();
            door2.OpenDoor();
        }
    }

    // Trigger the doors to close if both are open
    public void TriggerClose()
    {
        if (door1.IsOpen && door2.IsOpen)  // Only close if both doors are open
        {
            door1.CloseDoor();
            door2.CloseDoor();
        }
    }
}
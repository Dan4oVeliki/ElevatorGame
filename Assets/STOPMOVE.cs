using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StopMove : MonoBehaviour
{
    public Material mat;
    public static int DistanceID = Shader.PropertyToID("_Y");
    public float currSpeed = 1.0f; // Initial speed
    public bool dothat;

    private float targetSpeed = 0.0f; // Target speed to decelerate to
    private float decelerationRate = 0.2f; // Higher value means quicker deceleration

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dothat = true;
        }

        if (dothat)
        {
            // Gradually decrease `currSpeed` towards `targetSpeed`
            currSpeed = Mathf.MoveTowards(currSpeed, targetSpeed, decelerationRate * Time.deltaTime);

            // Update shader property
            mat.SetFloat(DistanceID, currSpeed);

            // Stop updating when `currSpeed` reaches `targetSpeed`
            if (Mathf.Approximately(currSpeed, targetSpeed))
            {
                dothat = false; // Stop further updates
                Debug.Log("Stopped moving");
            }

            Debug.Log($"Speed: {currSpeed}");
        }
    }
}
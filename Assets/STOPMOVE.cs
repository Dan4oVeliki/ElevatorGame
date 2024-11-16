using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class STOPMOVE : MonoBehaviour
{
    public Material mat;
    public static int DistanceID = Shader.PropertyToID("direction");
    public float currSpeed;
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {SlowDown();}
    }
    public void SlowDown()
    {
        while (currSpeed > 0)
        {
            mat.SetFloat(DistanceID, currSpeed - 0.001f);
            Debug.Log("amongus");
        }
        mat.SetFloat(DistanceID, 0);

    }
}

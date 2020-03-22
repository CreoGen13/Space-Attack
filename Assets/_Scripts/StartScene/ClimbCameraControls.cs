using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbCameraControls : MonoBehaviour
{
    GameObject text;
    private Quaternion mainQ;
    void Start()
    {
        mainQ = transform.rotation;
    }

    void Update()
    {
        transform.rotation = mainQ * Quaternion.Euler(new Vector3(-0.001f * Input.mousePosition.y, 0.001f * Input.mousePosition.x, 0));
    }
}
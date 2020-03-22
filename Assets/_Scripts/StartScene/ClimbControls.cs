using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbControls : MonoBehaviour
{
    GameObject text;
    public Vector3 mainPos;
    void Start()
    {
        // = GameObject.Find("Main Camera").gameObject;
        mainPos = transform.position;
    }

    void Update()
    {
        transform.position = mainPos + new Vector3(0.0004f* Input.mousePosition.x, 0.0004f*Input.mousePosition.y, 0);
    }
}

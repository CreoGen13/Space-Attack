using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
    private float speed;
    private void Start()
    {
        speed = Random.Range(-2f, -4f);
         Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}

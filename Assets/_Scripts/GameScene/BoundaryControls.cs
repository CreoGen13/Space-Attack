using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryControls : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}

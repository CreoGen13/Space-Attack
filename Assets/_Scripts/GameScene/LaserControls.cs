using UnityEngine;

public class LaserControls : MonoBehaviour
{
    private float speed = 50;
    void Update()
    {
        transform.Translate(new Vector3(0, (float)(0.01 * speed), 0));
    }
}

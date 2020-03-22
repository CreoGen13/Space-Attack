using UnityEngine;

public class Destroying : MonoBehaviour
{
    public float lifetime;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}

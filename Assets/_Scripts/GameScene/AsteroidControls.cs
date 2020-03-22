using UnityEngine;

public class AsteroidControls : MonoBehaviour
{
    public GameObject explosion;
    public AudioClip asteroidExplosionSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(asteroidExplosionSound, Camera.main.transform.position, 1.0f);
            if (other.tag == "Laser")
                DataHolder.score += 50;
            if (other.tag == "Component")
                DataHolder.isDamaged = true;
            else
                Destroy(other.gameObject);
        }
    }
}

using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    private float speed;

    public GameObject enemyExplosionPrefab;
    public AudioClip explosionSound;

    void Start()
    {
        speed = Random.Range(5f, 8f);
    }

    void Update()
    {
        transform.Translate(new Vector3(0, (float)(-0.01 * speed), 0));

        if (transform.position.y < -6)
        {
            transform.position = new Vector3(Random.Range(-7.9f, 7.9f), 6, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
            Destroy(this.gameObject);
            PlayerControls player = collision.GetComponent<PlayerControls>();
            if(player != null)
                player.HealthDown();
        }
    }
}

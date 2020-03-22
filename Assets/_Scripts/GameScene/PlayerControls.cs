using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    #region INITIALIZING
    private int speed = 15;
    private float verticallInput;
    private float horizontalInput;
    private float nextFireLeft;
    private float nextFireRight;
    private int healthPoints = 3;
    private float fireRate = 0.35f;
    private float tilt = -30;

    public GameObject playerExplosionPrefab;
    public GameObject laserPrefab;
    public AudioClip playerExplosionSound;
    public AudioClip laserSound;
    #endregion

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    void Update()
    {
        Movement();
        Shooting();
        HealthDown();
    }
    
    public void HealthDown()
    {
        if (DataHolder.isDamaged)
        {
            healthPoints--;
            DataHolder.isDamaged = false;
            if (healthPoints == 0)
            {
                Destroy(this.gameObject);
                Instantiate(playerExplosionPrefab, transform.position, Quaternion.Euler(90, 0, 0));
                AudioSource.PlayClipAtPoint(playerExplosionSound, Camera.main.transform.position, 0.6f);
                DataHolder.gameOver = true;
            }
        }
    }
    private void Movement()
    {
        verticallInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(new Vector3((float)0.01 * speed * horizontalInput, 0, (float)(0.01 * speed * verticallInput)));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.08f, 8.08f), 0, Mathf.Clamp(transform.position.z, -1.97f, 4f));
        transform.rotation = Quaternion.Euler(0, 0, horizontalInput*tilt);
    }
    private void Shooting()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextFireLeft)
            {
                nextFireLeft = Time.time + fireRate;
                AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, 1.0f);
                Instantiate(laserPrefab, transform.position + new Vector3(-0.229f, 0.02f, 0.853f), Quaternion.Euler(90, 0, 0));
            }
        }
        if (Input.GetMouseButton(1))
        {
            if (Time.time > nextFireRight)
            {
                nextFireRight = Time.time + fireRate;
                AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, 1.0f);
                Instantiate(laserPrefab, transform.position + new Vector3(0.229f, 0.02f, 0.853f), Quaternion.Euler(90, 0, 0));
            }
        }
    }
}

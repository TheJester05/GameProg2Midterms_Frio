using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootInterval = 1.0f;
    private Color playerColor;
    
    // Define the four colors
    private Color[] colors = new Color[] { Color.red, Color.green, Color.blue, Color.yellow };

    // Reference to the detection zone
    private DetectionZone detectionZone;

    void Start()
    {
        // Set initial color from the predefined array
        playerColor = GetRandomColor();
        GetComponent<Renderer>().material.color = playerColor;

        // Invoke a function repeatedly for shooting at fixed intervals
        InvokeRepeating("AttemptShoot", 0, shootInterval);
        
        // Get the DetectionZone component from the child object
        detectionZone = GetComponentInChildren<DetectionZone>();
    }

    void Update()
    {
        // Change color on player click
        if (Input.GetMouseButtonDown(0))
        {
            ChangeColor();
        }
    }

    // Attempts to shoot only if an enemy is in range
    void AttemptShoot()
    {
        if (detectionZone.IsEnemyInRange())
        {
            ShootBullet(detectionZone.GetNearestEnemy());
        }
    }

    void ShootBullet(GameObject targetEnemy)
    {
        if (targetEnemy != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<BulletController>().SetBulletColor(playerColor);
            bullet.transform.localScale = new Vector3(1f, 1f, 1f);  // Adjust scale if needed
        }
    }

    void ChangeColor()
    {
        playerColor = GetRandomColor();
        GetComponent<Renderer>().material.color = playerColor;
    }

    // Helper function to get a random color from the predefined array
    Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Length)];
    }
}


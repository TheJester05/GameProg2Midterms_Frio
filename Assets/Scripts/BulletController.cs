using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private Transform targetEnemy;

    void Start()
    {
        FindNearestEnemy();
    }

    void Update()
    {
        if (targetEnemy != null)
        {
            Vector3 direction = (targetEnemy.position - transform.position).normalized;
            transform.position += direction * bulletSpeed * Time.deltaTime;
        }
        else
        {
            // Move forward if no enemy is found
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        }
    }

    public void SetBulletColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            targetEnemy = nearestEnemy.transform;
        }
    }

    // Check for collision with an enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Color enemyColor = other.GetComponent<Renderer>().material.color;
            if (GetComponent<Renderer>().material.color == enemyColor)
            {
                // Destroy both the bullet and enemy if the colors match
                Destroy(other.gameObject); // Destroy the enemy
            }
            // Destroy the bullet in both cases (whether or not the colors match)
            Destroy(gameObject); 
        }
    }
}

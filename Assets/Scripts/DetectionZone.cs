using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    private GameObject nearestEnemy;
    private bool enemyInRange = false;
    
    // Getter method for checking if an enemy is in range
    public bool IsEnemyInRange()
    {
        return enemyInRange;
    }

    // Getter method to access the nearest enemy
    public GameObject GetNearestEnemy()
    {
        return nearestEnemy;
    }

    // Trigger detection for enemies entering the range
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            nearestEnemy = other.gameObject;
            enemyInRange = true;
        }
    }

    // Trigger detection for enemies leaving the range
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.gameObject == nearestEnemy)
            {
                nearestEnemy = null;
                enemyInRange = false;
            }
        }
    }
}


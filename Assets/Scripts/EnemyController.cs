using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;       // Speed of the enemy
    private GameObject player;          // Reference to the player

    // Define the four colors
    private Color[] colors = new Color[] { Color.red, Color.green, Color.blue, Color.yellow };

    void Start()
    {
        player = GameObject.FindWithTag("Player");  // Find the player by tag

        // Set a random color from the predefined array
        GetComponent<Renderer>().material.color = GetRandomColor();
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction towards the player
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    // Helper function to get a random color from the predefined array
    Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Length)];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger Game Over logic
            Debug.Log("Game Over!");

            // Call GameOverManager to handle game over logic
            GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
            if (gameOverManager != null)
            {
                gameOverManager.TriggerGameOver();  // Show game over screen
            }
        }
    }
}

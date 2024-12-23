using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance; // Singleton instance for easy access

    private List<GameObject> enemies = new List<GameObject>();

    private void Awake()
    {
        // Ensure only one instance of EnemyManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Find all enemies in the scene and add them to the list
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }

        // Check if all enemies are destroyed
        if (enemies.Count == 0)
        {
            AdvanceToNextLevel();
        }
    }

    private void AdvanceToNextLevel()
    {
        // Load the next level (adjust as needed)
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}

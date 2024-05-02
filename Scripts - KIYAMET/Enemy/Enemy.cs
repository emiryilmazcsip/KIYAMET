using UnityEngine;

public class Enemy : MonoBehaviour //the actual enemy script. This is how they take damage and die.
{
    public EnemyManager enemyManager;
    private Animator spriteAnim;
    private AngleToPlayer angleToPlayer;
    private float enemyHealth = 2f;
    public GameObject gunHitEffect;

    private void Start()
    {
        spriteAnim = GetComponentInChildren<Animator>();
        angleToPlayer = GetComponent<AngleToPlayer>(); // Corrected line to get AngleToPlayer component
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    void Update()
    {
        spriteAnim.SetFloat("spriteRot", angleToPlayer.lastIndex);

        if (enemyHealth <= 0)
        {
            Die(); // Enemy dies
        }
    }

    public void TakeDamage(float damage)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
    }

    // Function to handle enemy's death
    private void Die()
    {
        if (enemyManager != null)
        {
            enemyManager.RemoveEnemy(this); // Remove from EnemyManager's list
        }
        Destroy(gameObject); // Destroy the enemy game object
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour //This script is how the enemy can damage the player.
{
    private bool damagingPlayer;
    private PlayerHealth playerHealth;

    public int damageAmount = 10;
    public float timeBetweenDamage = 1.5f;

    private float damageCounter;

    // Start is called before the first frame update
    void Start()
    {
        damageCounter = timeBetweenDamage;
        playerHealth = FindObjectOfType<PlayerHealth>(); // I know this is not effecient but it will do.
    }

    // Update is called once per frame
    void Update()
    {
        if (damagingPlayer)
        {
            if (damageCounter > timeBetweenDamage)
            {
                playerHealth.DamagePlayer(damageAmount);
                damageCounter = 0f;
            }

            damageCounter += Time.deltaTime;
        }
        else
        {
            damageCounter = 0f;
        }
    }

    private void OnTriggerEnter(Collider other) // If the enemy touches the players collider. Take damage!
    {
        if (other.CompareTag("Player"))
        {
            damagingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other) // If the enemy doesn't touch the collider. Then NAH!
    {
        if (other.CompareTag("Player"))
        {
            damagingPlayer = false;
        }
    }
}

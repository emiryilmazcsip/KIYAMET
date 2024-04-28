using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
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
        playerHealth = FindObjectOfType<PlayerHealth>(); // You might want to find the player health in a more efficient way depending on your setup
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damagingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damagingPlayer = false;
        }
    }
}

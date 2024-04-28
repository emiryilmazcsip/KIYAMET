using UnityEngine;

public class DamageTrigger : MonoBehaviour
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
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(damagingPlayer)
        {
            //damage player in time between
            if(damageCounter > timeBetweenDamage)
            {
                //damage the mans
                playerHealth.DamagePlayer(damageAmount);

                //restart it!
                damageCounter = 0f;

            }

            //add to counter.
            damageCounter += Time.deltaTime;
        }
        else
        {
            //damage counter reset always like this
            damageCounter = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            damagingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            damagingPlayer = false;
        }
    }
}

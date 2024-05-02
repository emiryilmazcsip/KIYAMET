using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour // Player health script. This is how the game manages player health/ damage taken/ and pickups gotten.
{
    public int maxHealth;
    private int health;

    public int maxArmor;
    private int armor;

    public AudioSource playerAudioSource; // Audio source for player damage
    public AudioClip playerHurtClip; // Audio clip for player hurt

    public AudioSource armorAudioSource; // Audio source for armor damage
    public AudioClip armorHurtClip; // Audio clip for armor hurt

    void Start()
    {
        health = maxHealth;
        armor = maxArmor;
        CanvasManager.Instance.UpdateHealth(health);
        CanvasManager.Instance.UpdateArmor(armor);
    }

    void Update()
    {
        //temp test func
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            DamagePlayer(30);
            Debug.Log("Player has been Damaged");
        }
    }

    public void DamagePlayer(int damage)
    {
        health -= damage;

        // Play player damage audio clip every time player is damaged
        playerAudioSource.PlayOneShot(playerHurtClip);

        if (armor > 0)
        {
            // Damage armor
            if (armor >= damage)
            {
                armor -= damage;
            }
            else
            {
                int remainingDamage = damage - armor;
                armor = 0;
                health -= remainingDamage;
            }
        }

        if (health <= 0)
        {
            // Player is dead
            Debug.Log("Player Died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reset the scene
        }

        CanvasManager.Instance.UpdateHealth(health);
        CanvasManager.Instance.UpdateArmor(armor);
    }

    public void GiveHealth(int amount, GameObject pickup)
    {
        if (health < maxHealth)
        {
            health += amount;
            Destroy(pickup);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        CanvasManager.Instance.UpdateHealth(health);
    }

    public void GiveArmor(int amount, GameObject pickup)
    {
        if (armor < maxArmor)
        {
            armor += amount;
            Destroy(pickup);
        }

        if (armor > maxArmor)
        {
            armor = maxArmor;
        }

        CanvasManager.Instance.UpdateArmor(armor);
    }
}

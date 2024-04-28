using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI ammo;

    public Image healthIndicator;

    public Sprite health1; //good as new!
    public Sprite health2;
    public Sprite health3;
    public Sprite health4; //dead man walking

    public GameObject redKey;
    public GameObject blueKey;
    public GameObject greenKey;

    public Sprite damageOverlaySprite; // Transparent sprite for damage overlay
    private Image damageOverlayImage; // Image component for the overlay

    private static CanvasManager _instance;
    public static CanvasManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        // Initialize damage overlay image
        damageOverlayImage = gameObject.AddComponent<Image>();
        damageOverlayImage.sprite = damageOverlaySprite;
        damageOverlayImage.color = new Color(1f, 1f, 1f, 0f); // Make it fully transparent initially
        damageOverlayImage.enabled = false; // Hide the overlay by default
    }

    //methods for keeping UI up to date

    public void UpdateHealth(int healthValue)
    {
        health.text = healthValue.ToString() + "%";
        UpdateHealthIndicator(healthValue);
        ShowDamageOverlay(); // Show damage overlay when health decreases
    }

    public void UpdateArmor(int armorValue)
    {
        armor.text = armorValue.ToString() + "%";
        ShowDamageOverlay(); // Show damage overlay when armor decreases
    }

    public void UpdateAmmo(int ammoValue)
    {
        ammo.text = ammoValue.ToString();
    }

    public void UpdateHealthIndicator(int healthValue)
    {
        if (healthValue >= 66)
        {
            healthIndicator.sprite = health1; //healthiest man alive
        }

        if (healthValue < 66 && healthValue >= 33)
        {
            healthIndicator.sprite = health2;
        }

        if (healthValue < 33 && healthValue > 0)
        {
            healthIndicator.sprite = health3;
        }

        if (healthValue <= 0)
        {
            healthIndicator.sprite = health4; //dead as hell ;)
        }
    }

    public void UpdateKeys(string keyColor)
    {
        if (keyColor == "red")
        {
            redKey.SetActive(true);
            ShowOverlay();
        }

        if (keyColor == "green")
        {
            greenKey.SetActive(true);
            ShowOverlay();
        }

        if (keyColor == "blue")
        {
            blueKey.SetActive(true);
            ShowOverlay();
        }
    }

    public void ClearKeys()
    {
        redKey.SetActive(false);
        greenKey.SetActive(false);
        blueKey.SetActive(false);
    }

    // Method to show the damage overlay
    public void ShowDamageOverlay()
    {
        damageOverlayImage.enabled = true; // Show the overlay
        StartCoroutine(FadeOutOverlay()); // Start fading out the overlay
    }

    // Coroutine to fade out the overlay
    private IEnumerator FadeOutOverlay()
    {
        Color color = damageOverlayImage.color;
        color.a = 1f; // Start with full opacity
        damageOverlayImage.color = color;

        while (damageOverlayImage.color.a > 0)
        {
            color.a -= Time.deltaTime * 2f; // Adjust the fading speed as needed
            damageOverlayImage.color = color;
            yield return null;
        }

        damageOverlayImage.enabled = false; // Hide the overlay when fully faded out
    }

    // Method to show the overlay
    private void ShowOverlay()
    {
        damageOverlayImage.enabled = true; // Show the overlay
        StartCoroutine(FadeOutOverlay()); // Start fading out the overlay
    }
}

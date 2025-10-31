using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;
    public float playerHealth, maxPlayerHealth = 100f;
    float lerpSpeed;

    private void Start()
    {
        playerHealth = maxPlayerHealth;
    }

    private void Update()
    {
        healthText.text = playerHealth + "%";
        if (playerHealth > maxPlayerHealth) playerHealth = maxPlayerHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerHealth / maxPlayerHealth, lerpSpeed);

    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (playerHealth / maxPlayerHealth));
        healthBar.color = healthColor;
    }

    public void Damage(float damagepoints)
    {
            if (playerHealth > 0f)
                playerHealth -= damagepoints;

    }
    public void Heal(float healingPoints)
    {
        if (playerHealth < maxPlayerHealth)
            playerHealth += healingPoints;
    }
}

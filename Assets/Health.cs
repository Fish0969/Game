using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;
    public float playerHealth, maxPlayerHealth = 100f;
    float lerpSpeed;
    public GameObject characherchoser;
    public GameObject gameplay;
    public GameObject restart;
    public GameObject continu;
    public GameObject cam;

    private void Start()
    {
        playerHealth = maxPlayerHealth;
    }

    private void Update()
    {
        healthText.text = playerHealth.ToString("F0") + "%";
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
        if (playerHealth <= 0f)
        {

            Debug.Log("You died");
            gameplay.SetActive(false);
            restart.SetActive(true);
            continu.SetActive(false);
            cam.SetActive(true);




        }

    }
    public void Heal(float healingPoints)
    {
        if (playerHealth < maxPlayerHealth)
            playerHealth += healingPoints;
    }
}

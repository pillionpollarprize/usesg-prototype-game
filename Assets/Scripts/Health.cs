using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Transform healthBar;
    public TextMeshProUGUI shieldText;
    public Transform shieldBar;
    public TextMeshProUGUI warningText;
    public int maxHealth;
    public int maxShield;
    public bool inAtmosphere = false;
    public bool isPlayer = false;

    int health;
    int shield;

    void Start()
    {
        health = maxHealth;
        shield = maxShield;
        if (isPlayer)
        {
            healthText.text = health.ToString();
            shieldText.text = shield.ToString();
        }
    }
    void Update()
    {
        if (isPlayer)
        {
            if (inAtmosphere == false && shield <= 0)
            {
                warningText.text = "WARNING! HIGH PRESSURE!";
            }
            else
            {
                warningText.text = "";
            }
        }
        
    }
    public void TakeDamage(int damage)
    {
        if(shield > 0)
        {
            shield = Mathf.Clamp(shield - damage, 0, maxShield);
        }
        else if(shield <= 0)
        {
            health = Mathf.Clamp(health - damage, 0, maxHealth);
        }
        if (isPlayer)
        {
            UpdateText();
            UpdateBar();
        }
        if (health <= 0)
        {
            if (isPlayer)
            {
                var camera = Camera.main;
                camera.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    public void UpdateText()
    {
        healthText.text = health.ToString();
        shieldText.text = shield.ToString();

    }
    public void UpdateBar()
    {
        var mult = healthBar.localScale.x;
        healthBar.localScale = new Vector3((mult * (float)health) / maxHealth, 0.5f, 1);
        shieldBar.localScale = new Vector3((mult * (float)shield) / maxShield, 0.5f, 1);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int maxHealth = 10;
    public Image healthBarImage;

    [SerializeField]
    int currentHealth = 10;

    void Start()
    {
        currentHealth = maxHealth;
        lastTime = Time.time;
    }

    float lastTime;

    private void Update()
    {
        if(Time.time - lastTime > 1)
        {
            Damage(1);
            lastTime = Time.time;
        }
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;
        Debug.Log((float)currentHealth / maxHealth);
        healthBarImage.fillAmount = (float)currentHealth / maxHealth;
        
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

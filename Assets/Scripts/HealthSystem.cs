using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int MaxHealth = 100;
    private int health;

    public Text healthText;
    public Image healthFiller;
    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
        RenderHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        RenderHealth();
        print(health);
        if(health<=0)
        {
            print("Died");
            Destroy(gameObject);
        }
    }  
    
    public void RenderHealth()
    {
        healthText.text = health.ToString();
        healthFiller.fillAmount = (float)health / (float)MaxHealth;
    }    
}

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
    public AudioSource gameLoseSound;
    private GameUIController gameUIController;
    // Start is called before the first frame update
    void Start()
    {
        gameUIController = GameObject.FindGameObjectWithTag("GameUIController").GetComponent<GameUIController>();

        health = MaxHealth;
        RenderHealth();

        StartCoroutine("Hunger");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        print(health);
        if(health<=0)
        {
            Kill();
        }
        RenderHealth();
    }  
    
    public void AddHealth(int healthAmount)
    {
        health += healthAmount;
        print(health);
        if (health > MaxHealth)
        {
            health = MaxHealth;
        }
        RenderHealth();
    }
    public void RenderHealth()
    {
        healthText.text = health.ToString();
        healthFiller.fillAmount = (float)health / (float)MaxHealth;
    }    
    public void Kill()
    {
        health = 0;
        print("Died");
        gameLoseSound.Play();
        Destroy(gameObject);
        gameUIController.OpenDeathPanel();
    }
    IEnumerator Hunger()
    {
        TakeDamage(1);
        yield return new WaitForSeconds(1);
        StartCoroutine("Hunger");
    }
}

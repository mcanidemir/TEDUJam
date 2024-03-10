using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   // public GameObject health_bar;
    public int maxHealth = 100;
    public float currentHealth;
    public float regen;
    public bool dummy = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    private void Update()
    {
       // health_bar.transform.localScale = new Vector3(0.35f * currentHealth / 100, 0.03f, 1);
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (!dummy)
            {
                Die();
            }
            else
            {
                currentHealth = maxHealth;
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public Animator anim;
    public float currentHealth;
    public float startingHealth;
    public float maxHealth;
    private bool dead=false;
    // public Image healthBar;
    public GameObject player;
    private float timer;
    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (currentHealth <= 0)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                Destroy(player);

            }
        }
    }
    public void TakeDamage(float _damage)
    {
        
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");

                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;
            }
        }
    }
}

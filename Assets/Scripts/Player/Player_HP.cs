using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public Animator anim;
    public float health;
    public float maxHealth;
   // public Image healthBar;
    public GameObject player;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                Destroy(player);

            }
        }
    }
}

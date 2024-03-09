using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Damage : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 50;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("Enemy"))
        //{
        //    Attack();
        //    Destroy(gameObject);
        //}
        //else if (other.gameObject.CompareTag("Floor"))
       // {
        //    Destroy(gameObject);
        //}
    }
    void Attack()
    {

        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage enemies
        //foreach (Collider2D enemy in hitEnemies)
       // {
           //enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
       // }
    }
}

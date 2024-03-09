using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class kunai : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D kunai_rb;
    private Vector2 direction;
    public int attackDamage = 50;
    [SerializeField] private GameObject kunai_;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        kunai_rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        kunai_rb.velocity = direction * speed;
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Attack(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
    void Attack(GameObject enemy)
    {

        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.TakeDamage(attackDamage);
        }

    }

}

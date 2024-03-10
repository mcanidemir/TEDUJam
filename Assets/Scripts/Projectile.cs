using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject player;
    private Transform player_;
    private Rigidbody2D rb;
    public float force;
    public float damage;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;


        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Player_HP playerScript = player.GetComponent<Player_HP>();
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerScript != null)
            {
                Debug.Log("a");
                playerScript.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}

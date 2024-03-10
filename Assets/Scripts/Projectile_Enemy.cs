using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Enemy : MonoBehaviour
{
    [SerializeField] private GameObject Projectile_spawnpoint;
    public float speed = 5f;
    public float duration = 2f;
    private Rigidbody2D projectile_rb;
    private Vector2 direction;
    

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float shootingInterval = 2f; // Interval between shots
    private float shootTimer = 0f;



    // Start is called before the first frame update
    void Start()
    {
        projectile_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame



    private void Update()
    {
        // health_bar.transform.localScale = new Vector3(0.35f * currentHealth / 100, 0.03f, 1);
        // Update the shoot timer
        shootTimer += Time.deltaTime;

        // Check if it's time to shoot
        if (shootTimer >= shootingInterval)
        {
            Shoot();
            shootTimer = 0f; // Reset the shoot timer
        }
    }



    private void FixedUpdate()
    {
        projectile_rb.velocity = direction * speed;
    }
    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    
 
    public void Shoot()
    {
        // Instantiate the projectile at the spawn point
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);


        // Adjust the direction if needed (e.g., set the speed)
        // In this case, it moves horizontally, so we don't need to set the direction explicitly.

        // Play shooting sound effect or animation if needed
    }
}

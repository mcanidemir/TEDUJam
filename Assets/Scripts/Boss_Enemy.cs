using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Enemy : MonoBehaviour
{
    [SerializeField] private GameObject Melee_Enemy;
    [SerializeField] private GameObject Boss_Projectile;
    private int Boss_HP = 300;
    private bool spawningEnemies;
    private bool spawningProjectile;
    [SerializeField] private GameObject Spawnpoint1;
    [SerializeField] private GameObject Spawnpoint2;
    [SerializeField] private GameObject Spawnpoint3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //attack type 1 is ranged
        //attack type 2 is summon
        int attackType = Random.Range(0, 3);
        if (attackType == 1 && !spawningProjectile)
        {
                StartCoroutine(SpawnProjectileEnemies());
        }
        else if (attackType == 2 && !spawningEnemies)
        {
            StartCoroutine(SpawnMeleeEnemies());
        }

    }
    IEnumerator SpawnProjectileEnemies()
    {
        spawningProjectile = true;

        if (Boss_HP < 150)
        {
            Debug.Log("a");
            int numOfProjectiles = Random.Range(2, 5);

            for (int i = 0; i < numOfProjectiles; i++)
            {
            Instantiate(Boss_Projectile, gameObject.transform.position, Quaternion.identity);

            // Introduce a delay between instantiations (e.g., 1 second)
            yield return new WaitForSecondsRealtime(7f);
            }

        }
        else
        {
           
                Instantiate(Boss_Projectile, gameObject.transform.position, Quaternion.identity);

                // Introduce a delay between instantiations (e.g., 1 second)
                yield return new WaitForSecondsRealtime(7f);
            
        }
        spawningProjectile = false;
    }

    IEnumerator SpawnMeleeEnemies()
    {
        spawningEnemies = true;
        Instantiate(Melee_Enemy, Spawnpoint1.transform.position, Quaternion.identity);
        Instantiate(Melee_Enemy, Spawnpoint2.transform.position, Quaternion.identity);
        Instantiate(Melee_Enemy, Spawnpoint3.transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(35f);
        spawningEnemies = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer_Bullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawnpoint;
    private Vector3 spawnpoint_location;
    public Animator anim;
    private float timer = 1.5f;
    // Update is called once per frame
    void Update()
    {
        spawnpoint_location = spawnpoint.transform.position;
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Projectile"))
        {
            player_bullet();
            //anim.SetBool("shoot", true);
        }
        else
        {
            //anim.SetBool("shoot", false);

        }
    }
    public void player_bullet()
    {
        if (timer > 1.5)
        {
            Instantiate(bullet, spawnpoint_location, Quaternion.identity);
            timer = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    private GameObject player;
    public int angle_;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // Get the direction from the arrow to the player
        Vector3 directionToPlayer = player.transform.position - transform.position;

        // Calculate the rotation angle in degrees
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Rotate the arrow to face the player
        transform.rotation = Quaternion.AngleAxis(angle + angle_, Vector3.forward);
    }
}

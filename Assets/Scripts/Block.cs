using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Access the Collider2D component of the game object and set isTrigger to false
            Collider2D collider = gameObject.GetComponent<Collider2D>();

            if (collider != null)
            {
                collider.isTrigger = false;
            }
        }
    }
}

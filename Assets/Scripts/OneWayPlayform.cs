using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlayform : MonoBehaviour
{
    private GameObject OneWayPlatform;

    [SerializeField] private CapsuleCollider2D playerCollider;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            if (OneWayPlatform != null)
            {
                StartCoroutine(DisableColl());
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            OneWayPlatform = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            OneWayPlatform = null;
        }
    }
    private IEnumerator DisableColl()
    {
        BoxCollider2D platformCol = OneWayPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCol);
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreCollision(playerCollider, platformCol, false);
    }
}

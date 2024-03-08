using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public float JumpPower;
    private bool isJumping;
    private bool DoubleJump;
    private bool isFacingRight;

    private bool canDash = true;
    private bool isDashing;
    private float DashingPower;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
        }
        if (Input.GetButtonDown("Dash"))
        {
            Dash();
        }

        Flip();
        Debug.Log(KeyCode.LeftShift);
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float ogGravity = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(transform.localScale.x * DashingPower, 0f);
        tr.emitting = false;
        rb.gravityScale = ogGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }

    private void OnCollisionExit2D(Collision2D other)
    {
       
    }

}

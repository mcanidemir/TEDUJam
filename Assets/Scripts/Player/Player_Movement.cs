using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 5;
    private float speed_Increase = 0.5f;
    private float JumpPower = 10;
    private int JumpCount = 0;
    private int DoubleJump = 1;
    private bool isFacingRight;
    private int kunai_count = 10;
    public TMP_Text kunaicount;
    public TMP_Text money;


    private bool canDash = true;
    private bool isDashing;
    private float DashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private GameObject Kunai_spawnpoint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private GameObject kunai;

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

        if (Input.GetButtonDown("Jump") && JumpCount < DoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            JumpCount++;
        }
        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetButtonDown("Projectile"))
        {
            ThrowKnife(0);
            KunaiScore();
            
        }
        Flip();
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
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * DashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = ogGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            JumpCount = 0;
        }
    }

    public void ThrowKnife(int value)
    {
        if (kunai_count>0)
        {

        if (isFacingRight)
        {
        GameObject tmp = (GameObject)Instantiate(kunai, Kunai_spawnpoint.transform.position, Quaternion.Euler(new Vector3(0,0,-45)));
            tmp.GetComponent<kunai>().Initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(kunai, Kunai_spawnpoint.transform.position, Quaternion.Euler(new Vector3(0, 0, 135)));
            tmp.GetComponent<kunai>().Initialize(Vector2.left);
        }
            kunai_count--;
        }
    }
    public void SpeedIncrease()
    {
        speed += 0.5f;
    }
    public void KunaiCount()
    {
        kunai_count++;
    }
    public void CanDoubleJump()
    {
        DoubleJump = 2;
    }
    public void KunaiScore()
    {

        kunaicount.text =" "+ kunai_count;
    }
}
 
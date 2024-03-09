using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class kunai : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D kunai_rb;
    private Vector2 direction;
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

}

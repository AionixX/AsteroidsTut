using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    private Rigidbody2D rb = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
            rb.velocity = transform.up * speed;
        else 
            rb.velocity = Vector2.zero;
    }
}

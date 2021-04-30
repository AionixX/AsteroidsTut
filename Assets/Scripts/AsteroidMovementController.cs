using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Vector2 posMin = new Vector2(-12.5f, -7f);
    [SerializeField] private Vector2 posMax = new Vector2(12.5f, 7f);
    private Vector3 direction = Vector3.zero;
    private Rigidbody2D rb = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        direction.x = UnityEngine.Random.Range(-1f, 1f);
        direction.y = UnityEngine.Random.Range(-1f, 1f);

        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Move();
        CheckBoundaries();
    }

    // private void Move()
    // {
    //     Vector3 movement = Vector3.zero;
    //     movement += direction.normalized;
    //     movement *= speed;
    //     movement *= Time.deltaTime;
    //     transform.position += movement;
    // }

    private void CheckBoundaries()
    {
        Vector3 pos = transform.position;

        if (pos.x < posMin.x)
            pos.x = posMax.x;

        if (pos.x > posMax.x)
            pos.x = posMin.x;

        if (pos.y < posMin.y)
            pos.y = posMax.y;

        if (pos.y > posMax.y)
            pos.y = posMin.y;

        transform.position = pos;
    }
}

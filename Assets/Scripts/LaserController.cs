using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 5f;

    private void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition += transform.up * speed * Time.deltaTime;
        transform.position = newPosition;

        lifetime -= Time.deltaTime;

        if (lifetime <= 0f)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D _other)
    {
        if (_other.collider.CompareTag("Destroyable"))
        {
            _other.gameObject.SendMessage("Die", SendMessageOptions.DontRequireReceiver);
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}

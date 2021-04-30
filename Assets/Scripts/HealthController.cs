using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int healthPoints = 3;
    [SerializeField] private GameObject diePrefab = null;
    [SerializeField] private int dieObjectCount = 4;

    private void OnCollisionEnter2D(Collision2D _other)
    {
        if (_other.collider.CompareTag("Destroyable"))
        {
            healthPoints--;

            if (healthPoints <= 0)
                this.gameObject.SendMessage("Die");
        }
    }

    void Die()
    {
        if (diePrefab)
        {
            for (int i = 0; i < dieObjectCount; i++)
                Instantiate(diePrefab, transform.position, transform.rotation);
        }

        Destroy(this.gameObject);
    }
}

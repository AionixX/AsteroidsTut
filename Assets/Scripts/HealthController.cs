using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int healthPoints = 3;
    [SerializeField] private GameObject diePrefab = null;
    [SerializeField] private int dieObjectCount = 4;
    [SerializeField] private GameObject dieAnimation = null;
    [SerializeField] private int pointsWorth = 0;
    [SerializeField] private float respawnTime = 1.5f;

    private void OnCollisionEnter2D(Collision2D _other)
    {
        if (_other.collider.CompareTag("Destroyable"))
        {
            healthPoints--;

            if (healthPoints <= 0)
            {
                this.SendMessage("Die");
            }
            else
            {
                if (dieAnimation)
                    Instantiate(dieAnimation, transform.position, transform.rotation);

                StartCoroutine(RespawnIn(respawnTime));
            }
        }
    }

    void Die()
    {
        if (diePrefab)
        {
            for (int i = 0; i < dieObjectCount; i++)
                Instantiate(diePrefab, transform.position, transform.rotation);
        }

        if (dieAnimation)
            Instantiate(dieAnimation, transform.position, transform.rotation);

        GameManager.instance.AddPoints(pointsWorth);

        Destroy(this.gameObject);
    }

    public int GetHealth() { return healthPoints; }

    IEnumerator RespawnIn(float _time)
    {
        transform.position = new Vector3(1000f, 1000f, 1000f);
        yield return new WaitForSeconds(_time);
        transform.position = new Vector3(0f, 0f, -1f);
    }
}

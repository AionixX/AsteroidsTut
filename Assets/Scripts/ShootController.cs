using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab = null;
    [SerializeField] private Transform laserSpawnPosition = null;
    [SerializeField] private float cooldown = 1f;

    private float actualCooldown = 0f;

    private void Update()
    {
        if(Input.GetMouseButton(0) && actualCooldown <= 0f) {
            Instantiate(laserPrefab, laserSpawnPosition.position, laserSpawnPosition.rotation);
            actualCooldown = cooldown;
        }
        
        actualCooldown -= Time.deltaTime;
    }
}

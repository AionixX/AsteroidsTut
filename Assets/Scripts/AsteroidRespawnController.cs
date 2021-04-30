using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRespawnController : MonoBehaviour
{
    public void Die()
    {
        GameManager.instance.AsteroidDied();
    }
}

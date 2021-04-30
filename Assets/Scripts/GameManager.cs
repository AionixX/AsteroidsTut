using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab = null;

    public static GameManager instance = null;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Second GameManager found");
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AsteroidDied()
    {
        Instantiate(asteroidPrefab);
    }
}

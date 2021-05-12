using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private GameObject asteroidPrefab = null;

    [SerializeField] private int points = 0;

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

    public void AddPoints(int _amount) {
        points += _amount;
    }
}

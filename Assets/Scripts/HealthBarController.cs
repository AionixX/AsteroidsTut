using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private List<GameObject> hearts = new List<GameObject>();
    [SerializeField] private HealthController controller = null;

    void Update()
    {
        if (controller)
        {
            int lifeLeft = controller.GetHealth();

            for (int i = 0; i < hearts.Count; i++)
            {
                if (i < lifeLeft)
                    hearts[i].SetActive(true);
                else
                    hearts[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < hearts.Count; i++)
            {
                hearts[i].SetActive(false);
            }

            GameManager.instance.GameOver();
        }
    }
}

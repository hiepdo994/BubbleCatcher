using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBubble : MonoBehaviour
{
    public float timeDestroy = 5f;
    public float timeRemain = 0;
    public Transform spawner;
    public GameObject bubblePrefab;
    void Start()
    {
        if (spawner != null && bubblePrefab != null)
        {
            Instantiate(bubblePrefab, spawner.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeRemain += Time.deltaTime;
        if (timeRemain >= timeDestroy)
        {
            if (spawner != null && bubblePrefab != null)
            {
                Instantiate(bubblePrefab, spawner.position, Quaternion.identity);
            }
            timeRemain = 0f;

        }
    }
}

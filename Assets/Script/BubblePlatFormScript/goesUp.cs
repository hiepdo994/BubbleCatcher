using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goesUp : MonoBehaviour
{
    public float timeDestroy = 5f;
    public float timeRemain = 0;
    public float floatingUpForce = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * floatingUpForce * Time.deltaTime;
        timeRemain += Time.deltaTime;
        if (timeRemain >= timeDestroy)
        {
            Destroy(gameObject);
        }
    }
}

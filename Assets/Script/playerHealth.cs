using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    int health;
    void Start()
    {
        health = 5;
    }

    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            Debug.Log("Health is: " + health);
            //knockback();
        }      
     }
}

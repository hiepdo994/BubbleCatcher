using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{

    //attach to monster damage script if player touch then it will call this script 
    public FlashDamage flashing;

    //adjust health for testing
    [SerializeField]
    
    private int health;
    void Start()
    {
    }
    public void TakeDamage()
    {
           
            if (health > 0)
            {
                health--;
                Debug.Log("Take Damage " + health);
            flashing.Flash();
            }
            if (health <= 0)
            {
                health = 0; // Clamp health to zero
                Debug.Log("Game Over");
            }

    }
}

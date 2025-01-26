using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class AimAndShoot : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject[] bubbles;

    private float timer;
    private Quaternion gunRotation;
    public Animator animator;
    public GameObject bullet;
    public Transform weaponTransform;
    public bool canFire;
    public float timeBetweenFire;



    void Update()
    {
        gunRotation = transform.rotation;

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFire)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            animator.SetTrigger("Attack");
            
        }
    }

    void Firing()
    {
        bubbles[FindBubble()].transform.position = attackPoint.position;
        bubbles[FindBubble()].GetComponent<Bullet>().SetDirection(Mathf.Sign(transform.localScale.x));


        
    }

    private int FindBubble()
    {
        for(int i = 0; i< bubbles.Length; i++)
        {
            if (!bubbles[i].activeInHierarchy) return i;
        }
        return 0;
    }
}

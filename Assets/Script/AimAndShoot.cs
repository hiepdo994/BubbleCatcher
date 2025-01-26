using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class AimAndShoot : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private float timer;

    public float scalingDuration;
    public GameObject bullet;
    public Transform weaponTransform;
    public bool canFire;
    public float timeBetweenFire;


    private void Start()
    {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }

    void Update()
    {
       mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,rotZ);

        if (!canFire)
        {
            timer = Time.deltaTime;
            if (timer > timeBetweenFire)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            GameObject projectile = Instantiate(bullet, weaponTransform.position, Quaternion.identity);
        }
    }
}

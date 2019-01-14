using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_handler : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int bulletSpeed;

    bool shootKey;

    // Use this for initialization
    void Start()
    {
        bulletSpeed = 15;

    }

    // Update is called once per frame
    void Update()
    {
        //Storing Keys on bool values every frames
        seeKeysPressed();
        if (shootKey) Fire();

    }
    //Storing Keys on bool values
    void seeKeysPressed()
    {
        shootKey = Input.GetButtonDown("XButton"); 
    }

    //Firing the bullet
    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}

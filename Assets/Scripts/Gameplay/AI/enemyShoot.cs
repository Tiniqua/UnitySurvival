using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public GameObject Player;
    public float waitTime;
    private float currentTime;
    private bool shot;
    public GameObject bullet;
    public GameObject bulletSpawn;
    private Transform bulletSpawned;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");

        bulletSpawn = GameObject.Find("Gun/Bullet Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime == 0)
        {
            Shoot();
        }

        if (shot && currentTime < waitTime)
        {
            currentTime += 1 * Time.deltaTime;
        }

        if( currentTime >= waitTime)
        {
            currentTime = 0;
        }
    }

    public void Shoot()
    {
        shot = true;

        bulletSpawned = Instantiate(bullet.transform, bulletSpawn.transform.position, Quaternion.identity);
        bulletSpawned.rotation = this.transform.rotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float pointsToGive;
    public float cooldown;

    public GameObject player;
    public GameObject bullet;
    public GameObject bulletSpawn;
    private Transform bulletSpawned;

    private float currentWait;
    private bool shot;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        bulletSpawn = GameObject.Find("PistolHolder/BulletSpawnEnemy");
   
    
    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0) 
        {
            Die();
        }

        this.transform.LookAt(player.transform);

        if (currentWait == 0) 
        {
            Shoot();


        }

        if (shot && currentWait < cooldown)
            currentWait += 1 * Time.deltaTime;
        if (currentWait >= cooldown)
            currentWait = 0;

    }
    public void Shoot() 
    {
        shot = true;
        bulletSpawned = Instantiate(bullet.transform, bulletSpawn.transform.position ,Quaternion.identity );
        bulletSpawned.rotation = this.transform.rotation;

    
    }





    public void Die()
    {

        Destroy(this.gameObject);

        player.GetComponent<PlayerController>().points += pointsToGive;

    }


}

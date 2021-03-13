using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask collisionMask;

    public float speed;
    public float maxDist;
    public float damage;
    public Transform bullet;

    private float rotSpeed;
    private GameObject triggeringEnemy;
    private GameObject Player;
    private GameObject Enemy;

    private void Start()
    {

        Player = GameObject.FindWithTag("Player");
        Enemy = GameObject.FindWithTag("Enemy");
    }

    void Update()
    {


        bulletMove();
        DestroyBullet();



    }
    public void DestroyBullet()
    {
        if (maxDist >= 5)
        {
            Destroy(gameObject);

        }

    }
    public void bulletMove() 
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        bullet.Rotate(Vector3.up * Time.deltaTime * rotSpeed);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + .1f, collisionMask))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") 
        {
            Enemy.GetComponent<PlayerController>().hp -= damage;
            Destroy(Enemy);
        }

        if (other.tag == "Player")
        {

            Player.GetComponent<PlayerController>().hp -= damage;
            Destroy(Player);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask collisionMask;

    public float speed;
    public float maxDist;
    public float damage;
    public float maxTime;
    public float timeLeft;

    public Transform bullet;

    private float rotSpeed;

    public GameObject bulet;
    public GameObject sender;

    public void Start()
    {
        timeLeft = maxTime;
    }

    void Update()
    {
        Move();
        DestroyBullet();
    }
    public void DestroyBullet()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                timeLeft = maxTime;
                Destroy(bulet);

            }
            return;
        }

    }
    public void Move() 
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
            if (other.gameObject != this.sender && other.GetComponent<PlayerController>())
                other.GetComponent<PlayerController>().hp -= damage;
    }
}

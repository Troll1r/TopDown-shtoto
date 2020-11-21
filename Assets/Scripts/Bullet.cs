using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float maxDist;
    public float damage;

    private GameObject triggeringEnemy;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDist += 1 * Time.deltaTime;

        if (maxDist >=5) 
        {
            Destroy(this.gameObject);
        
        }



    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") 
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Enemy>().health -= damage;
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {

            Player.GetComponent<PlayerController>().hp -= 20;
        
        
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    protected Joystick joystik;
    public float moveSpeed;

    public GameObject bulletSpawn;
    public float cooldown;
    public float points;
    public float hp;
    public float maxHp;
    public GameObject Enemy;

    public GameObject playerObj;
    public GameObject bullet;

    private Rigidbody rb;
    private Transform bulletSpawned;
    void Start()
    {
        Enemy = GameObject.FindWithTag("Enemy");
        joystik = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
        hp = maxHp;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(Enemy.transform);
        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystik.Horizontal * 10f,rigidbody.velocity.y,joystik.Vertical * 10f);
        if (hp <= 0)
            Die();

    }

    public void Shoot()

    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawn.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawn.transform.rotation;







    }

    public void Die()
    {

        Destroy(this.gameObject);

    }
}

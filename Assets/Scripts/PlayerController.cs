using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public GameObject camera;
    public GameObject bulletSpawn;
    public float cooldown;
    public float points;
    public float hp;
    public float maxHp;

    public GameObject playerObj;
    public GameObject bullet;

    private Rigidbody rb;
    private Transform bulletSpawned;


    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = maxHp;

    }


    void Update()
    {
        //Rotate
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;
        if (playerPlane.Raycast(ray, out hitDist))
        {

            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);


        }
        //Move
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);


        //Shooting
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        
        }
        void Shoot() 
        {
            bulletSpawned = Instantiate(bullet.transform, bulletSpawn.transform.position, Quaternion.identity );
            bulletSpawned.rotation = bulletSpawn.transform.rotation;







        }
        if(hp <= 0)
            Die();
        
        
    }


    public void Die()
    {

        Destroy(this.gameObject);
    
    }






}

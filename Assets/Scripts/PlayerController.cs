using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Joystick joystikMove;
    public Joystick joystikRotation;
    public float moveSpeed;
    public float turnSpeed;
    public Image timeBar;
    public float maxTime;
    public float timeLeft;
    public Slider slider;
    public int Score;
    public GameObject ScoreText;
    public GameObject ScoreScreen;
    public float timel;
    public float mtime;

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
        timeLeft = maxTime;
        rb = GetComponent<Rigidbody>();
        hp = maxHp;
        SetMaxTime(maxTime);
    }


    void Update()
    {
        if (hp <= 0)
            Die();
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystikMove.Horizontal * moveSpeed, rigidbody.velocity.y, joystikMove.Vertical * moveSpeed);
        if (joystikRotation.Direction.magnitude > 0)
            transform.LookAt(Vector3.forward * joystikRotation.Vertical * turnSpeed + Vector3.right * joystikRotation.Horizontal * turnSpeed);
        Timer();
        SetHealth(timeLeft);
    }

    public void Shoot()

    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawn.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawn.transform.rotation;

        bulletSpawned.GetComponent<Bullet>().sender = this.gameObject;
    }

    public void Die()
    {
        Score++;
        ScoreText.GetComponent<Text>().text = "Score:" + Score.ToString();
        Destroy(this.gameObject);
        SceneManager.LoadScene(1);





    }
    public void Timer()
    {
            if (timeLeft >= 0)
            {
            timeLeft -= Time.deltaTime;
            
            if (timeLeft <= 0)
            {
                timeLeft = maxTime;
                Shoot();
                
            }
            return;
        }
    }

    public void SetMaxTime(float time) 
    {
        slider.maxValue = time;
        slider.value = time;
    
    }
    public void SetHealth(float time) 
    {
        slider.value = time; 
    }

}

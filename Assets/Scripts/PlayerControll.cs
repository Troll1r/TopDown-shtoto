using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    protected Joystick joystik;
    void Start()
    {
        joystik = FindObjectOfType<Joystick>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystik.Horizontal * 10f,rigidbody.velocity.y,joystik.Vertical * 10f);
        
    }
}

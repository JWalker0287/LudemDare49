using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterMotor motor;
    ProjectileLauncher gun;

    void Start()
    {
        gun = GetComponentInChildren<ProjectileLauncher>();
        motor = GetComponent<CharacterMotor>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        motor.Move(x);
        if (Input.GetButtonDown("Jump"))
        {
            motor.Jump();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            gun.Shoot(gun.transform.right);
        }
    }
}

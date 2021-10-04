using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterMotor motor;
    ProjectileLauncher gun;
    public static PlayerController player;

    void Start()
    {
        if (player == null) 
        {
            player = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
        gun = GetComponentInChildren<ProjectileLauncher>();
        motor = GetComponent<CharacterMotor>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        motor.Move(x);

        if (Input.GetButtonDown("Fire1"))
        {
            gun.Shoot(gun.transform.right);
        }
    }
}

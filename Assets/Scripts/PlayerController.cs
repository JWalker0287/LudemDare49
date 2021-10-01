using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterMotor motor;

    void Start()
    {
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
    }
}

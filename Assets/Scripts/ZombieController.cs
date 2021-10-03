using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    CharacterMotor motor;
    Animator anim;
    public float attackRadius = 1;
    public float followRadius = 20;

    void Start()
    {
        motor = GetComponent<CharacterMotor>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 diff = PlayerController.player.transform.position - transform.position;
        float xDist = PlayerController.player.transform.position.x - transform.position.x;
        xDist = Mathf.Abs(xDist);

        if (xDist <= attackRadius)
        {
            anim.SetTrigger("Attack");
            motor.Move(0f);
        }
        else if (xDist <= followRadius)
        {
            motor.Move(diff.normalized.x);
            anim.ResetTrigger("Attack");
        }
        else
        {
            motor.Move(0);
            anim.ResetTrigger("Attack");
        }
    }
}

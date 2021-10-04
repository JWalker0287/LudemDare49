using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    Rigidbody2D body;
    public float xspeed = 5;
    public float jumpHeight = 5;
    public LayerMask Environment;
    float inputX;

    Animator anim;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        body.velocity = new Vector2(inputX * xspeed, body.velocity.y);
        anim.SetFloat("XSpeed", Mathf.Abs(body.velocity.x));
        anim.SetFloat("YSpeed", body.velocity.y);
        if (body.velocity.x < 0 || body.velocity.x > 0) transform.right = new Vector2(inputX, 0);
    }

    public void Move(float x)
    {
        inputX = x;
    }

}

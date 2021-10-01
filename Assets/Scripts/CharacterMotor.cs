using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    Rigidbody2D body;
    public float xspeed = 5;
    public float jumpHeight = 5;
    float inputX;
    bool _onGround;
    public bool onGround {
        get { return _onGround; }
        private set { _onGround = value; }
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.velocity = new Vector2(inputX * xspeed, body.velocity.y);
    }

    public void Move(float x)
    {
        inputX = x;
    }

    public void Jump()
    {
        //if (!onGround) return;

        float jumpVelocity = Mathf.Sqrt(-2 * Physics2D.gravity.y * body.gravityScale * jumpHeight);
        body.velocity = new Vector2(body.velocity.x, jumpVelocity);
    }

    //void GroundCheck()
}

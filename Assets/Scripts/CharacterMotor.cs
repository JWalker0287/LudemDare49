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
        GroundCheck();

        body.velocity = new Vector2(inputX * xspeed, body.velocity.y);
    }

    public void Move(float x)
    {
        inputX = x;
    }

    public void Jump()
    {
        if (!onGround) return;

        float jumpVelocity = Mathf.Sqrt(-2 * Physics2D.gravity.y * body.gravityScale * jumpHeight);
        body.velocity = new Vector2(body.velocity.x, jumpVelocity);
    }

    void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.05f, Environment);
        onGround = (colliders.Length > 0);
        colliders = Physics2D.OverlapCircleAll(transform.position+Vector3.right*0.25f, 0.05f, Environment);
        onGround = onGround | (colliders.Length > 0);
        colliders = Physics2D.OverlapCircleAll(transform.position+Vector3.left*0.25f, 0.05f, Environment);
        onGround = onGround | (colliders.Length > 0);
    }
}

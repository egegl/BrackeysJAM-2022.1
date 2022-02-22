using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PUT THIS SCRIPT ON PLAYER GAME OBJECT SO IT CAN MOVE

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Camera _cam;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _cam = Camera.main;
    }

    // ANIMATE THE PLAYER IN ACCORDANCE TO IT'S RIGIDBODY2D'S VELOCITY
    void Update()
    {
        _anim.SetFloat("Horizontal", _rb.velocity.x);
    }

    // MAKE PLAYER LOOK AT THE CURSOR AND MOVE FORWARD
    void FixedUpdate()
    {
        // TRANSFORM ROTATION TO CURSOR POSITION
        Vector3 diff = (_cam.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        // MOVE FORWARD
        _rb.velocity = transform.right * moveSpeed;
    }
}
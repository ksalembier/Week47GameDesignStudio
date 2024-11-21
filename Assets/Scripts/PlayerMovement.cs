using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movement;
    public Rigidbody2D rb; // trying to connect it in the editor to see what happens
    public Animator animator;

    // private void Awake()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    // }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        movement.Set(InputManager.movement.x, InputManager.movement.y);
        rb.velocity = movement * moveSpeed;
        if (rb.velocity != Vector2.zero)
            PlayerMove();
        else PlayerStop();
    }

    public void PlayerMove()
    {
        animator.SetBool("IsMove", true);
    }

    public void PlayerStop()
    {
        animator.SetBool("IsMove", false);
    }


}

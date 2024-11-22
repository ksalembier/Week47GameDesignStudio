using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movement;
    public Rigidbody2D rb; 
    public Animator animator;

    private void Update()
    {
        movement.Set(InputManager.movement.x, InputManager.movement.y);
        rb.velocity = movement * moveSpeed;
        if (rb.velocity != Vector2.zero) { PlayerMove(); }
        else { PlayerStop(); }
    }

    public void PlayerMove()
    {
        animator.SetBool("Ismove",true);
    }

    public void PlayerStop()
    {
        animator.SetBool("Ismove",false);
    }
}

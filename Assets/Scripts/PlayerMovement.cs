using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movement;
    public Rigidbody2D rb; // trying to connect it in the editor to see what happens

    // private void Awake()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    // }

    private void Update()
    {
        movement.Set(InputManager.movement.x, InputManager.movement.y);
        rb.velocity = movement * moveSpeed;
    }
}

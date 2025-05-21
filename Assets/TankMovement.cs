using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Швидкість руху
    private Rigidbody2D rb;
    private Vector2 movement; // Зберігає напрямок руху
    public KeyCode MovementUp, MovementDown, MovementRight, MovementLeft;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Зчитування вводу
        movement = Vector2.zero;

        if (Input.GetKey(MovementUp))
        {
            movement.y = 1;
        }
        if (Input.GetKey(MovementDown))
        {
            movement.y = -1;
        }
        if (Input.GetKey(MovementRight))
        {
            movement.x = 1;
        }
        if (Input.GetKey(MovementLeft))
        {
            movement.x = -1;
        }

        // Нормалізація, щоб швидкість була стабільна під кутом (по діагоналі)
        movement = movement.normalized;
        animator.SetFloat("Speed", movement.magnitude);
    }

    void FixedUpdate()
    {
        // Рух
        rb.velocity = movement * moveSpeed;

        // Якщо танк рухається — повертаємо його
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90f; // Мінус 90 щоб "норма" була на північ
        }
    }
}
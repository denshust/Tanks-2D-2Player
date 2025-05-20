using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TankMovement : MonoBehaviour
{
    private PhotonView photonView;
    public float moveSpeed = 5f; // Швидкість руху
    private Rigidbody2D rb;
    private Vector2 movement; // Зберігає напрямок руху
    public KeyCode MovementUp, MovementDown, MovementRight, MovementLeft;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (photonView.IsMine)
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
        }
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
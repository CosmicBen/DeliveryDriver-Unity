using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 45.0f;
    [SerializeField] private float slowSpeed = 10.0f;
    [SerializeField] private float boostSpeed = 15.0f;
    private float moveSpeed = 10.0f;

    private void Start()
    {
        moveSpeed = slowSpeed;
    }

    private void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0.0f, 0.0f, -steerAmount, Space.Self);
        transform.Translate(0.0f, moveAmount, 0.0f, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            moveSpeed = boostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }
}

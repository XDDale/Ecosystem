using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rabbit : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(ChangeDirection), 1f, 1f);
    }

    private void ChangeDirection()
    {
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void Update()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Grass"))
        {
            Destroy(other.gameObject);
            // Optional: Implement logic to spawn a new rabbit here
        }
        else if (other.gameObject.CompareTag("Fox"))
        {
            Destroy(gameObject); // Rabbit gets eaten by the fox
        }
    }
}

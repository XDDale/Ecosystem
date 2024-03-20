using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Fox : MonoBehaviour
{
    public GameObject foxPrefab;
    public float moveSpeed = 5f;
    public float lifeTime = 30f;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private float deathTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        deathTime = Time.time + lifeTime;
        InvokeRepeating(nameof(ChangeDirection), 1f, 1f);
    }

    private void ChangeDirection()
    {
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void Update()
    {
        if (Time.time >= deathTime)
        {
            Destroy(gameObject); // Fox dies of old age
        }
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rabbit"))
        {
            Destroy(other.gameObject); // Eat the rabbit
            Instantiate(foxPrefab, transform.position, Quaternion.identity); // Spawn a new fox
        }
    }

}

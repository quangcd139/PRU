using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy properties

    public int health;

    public float speed;

    // Reference to components

    private Rigidbody rb;
    private Animator anim;

    // Initialization

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Movement

    public void Move()
    {
        rb.velocity = transform.forward * speed;
        anim.SetFloat("Speed", speed);
    }
}

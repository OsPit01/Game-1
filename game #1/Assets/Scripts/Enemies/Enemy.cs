using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public int damage;
    public float Health { get => health; set => health = value; }
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            health -= 5;
        }


        if (collision.CompareTag("Bullet"))
        {
            health -= 5;
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy();
        }
    }
}


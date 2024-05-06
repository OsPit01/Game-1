using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float health;
    public float speed = 3f;
    public int damage;

    public string collisionTag;

    private bool isCollision;

    public bool isDestroyed = false;

    private Rigidbody2D _rb;
    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;
    Transform target;
    public GameObject effect;



    public float Health { get => health; set => health = value; }


    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;

        _rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
   
       
    }

    void Update()
    {

            EnemyFollow();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == collisionTag && !isCollision)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Player player = collision.gameObject.GetComponent<Player>();
            isCollision = true;
            player.TakeHit(damage);
        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        isCollision = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject,.5f);
            --health;
            spriteRend.material = matBlink;
           
            if (health <= 0)
            {
                KillEnemy();
            }
            else
            {
                Invoke("ResetMaterial", .2f);
            }

        }
    }
   
    void ResetMaterial()
    {
        spriteRend.material = matDefault;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void KillEnemy()
    {
        isDestroyed = true;
        Destroy(gameObject);
    }
  
    public void EnemyFollow()
    {
  
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        
    }
}


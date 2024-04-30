using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int damage;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * speed;
    }
    private void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy();
        }
    }
    private void Destroy()
    {
        Enemy enemy = gameObject.AddComponent<Enemy>();
        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }

}



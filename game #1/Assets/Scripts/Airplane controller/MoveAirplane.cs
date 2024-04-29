using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAirplane : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float HorizontalMove = 0f;
    public float speed = 1f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed; 
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(HorizontalMove * 10,_rb.velocity.y);
    }
}

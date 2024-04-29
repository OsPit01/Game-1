using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAirplane : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 Move;
    public float speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
       Move.x = Input.GetAxisRaw("Horizontal") * speed;
        Move.y = Input.GetAxis("Vertical") * speed;
    }

    private void FixedUpdate()
    {
        // _rb.velocity = new Vector2(HorizontalMove * 10,_rb.velocity.y);
        _rb.MovePosition(_rb.position + Move * speed * Time.fixedDeltaTime);
    }
}

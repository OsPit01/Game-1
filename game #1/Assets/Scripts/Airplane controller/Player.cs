
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 Move;
    public float speed;
    public int health;
    public bool facingRight = true;

    public int numOfHearts;
    public Image[] hearts;
    public Sprite fulHearts;
    public Sprite emptyHearts;
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
        if (facingRight == false && Move.x > 0)
        {
            Flip();
            
        }
        else if (facingRight == true && Move.x < 0)
        {
            Flip();
        }
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fulHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void ChangeHealth(int healthValue)
    {
        health += healthValue;
    }
    public void TakeHit(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180, 0);
    }
}

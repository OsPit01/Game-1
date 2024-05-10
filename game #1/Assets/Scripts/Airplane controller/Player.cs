
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 Move;

    [Header("Controls")]
   [SerializeField] private float speed;

    [Header("Health")]
    [SerializeField] private int health;
    [SerializeField] private int numOfHearts;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fulHearts;
    [SerializeField] private Sprite emptyHearts;

    [Header("Bool")]
    [SerializeField] private bool facingRight = true;

    [Header("Panel")]
    public GameObject panel;

    [Header("TakeBonus")]
    public GameObject potionEffect;

    [Header("Weapons")]
    [SerializeField] private List<GameObject> unlockedWeapons;
    [SerializeField] private GameObject[] allWeapons;
    [SerializeField] private Image weaponIcon;


    private Shooting bullet;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        bullet = GetComponent<Shooting>();
       
    }


    void Update()
    {
        Move.x = Input.GetAxisRaw("Horizontal") * speed;
        Move.y = Input.GetAxis("Vertical") * speed;
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Potion"))
        {
            ChangeHealth(2);
            Instantiate(potionEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        //operator for weapons
        else if (collision.CompareTag("Weapon"))
        {
            bullet.TakeProjectile(allWeapons[1]);
            Destroy(collision.gameObject);
           
        }
       
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
            panel.SetActive(true);
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180, 0);
    }

    //method for switchWeapon
    
}

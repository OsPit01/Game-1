using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Sounds
{
    [Header("Controls")]
   // [SerializeField] private float timeBtwAttack;
   // [SerializeField] private float startTimeBtwAttack;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float timeDEstroy = 5f;

    [Header("Health")]
    [SerializeField] private float health;

    [Header("Damage")]
    [SerializeField] private int damage;

    [Header("CollisionTag")]
    public string collisionTag;
    private bool isCollision;
    public bool isDestroyed = false;

    [Header("Tag")]
    Transform target;

    [Header("Transform")]
    public Vector3 spawPos;

    [Header("Effect")]
    public GameObject effect;

    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;
    private ScoreManager score;
    private UnityEngine.Object explosion;
    private UnityEngine.Object enemyRef;
  
   


    public float Health { get => health; set => health = value; }


    void Start()
    {
        spawPos = transform.position;
        enemyRef = Resources.Load("Enemy");
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        score = FindAnyObjectByType<ScoreManager>();

        explosion = Resources.Load("Explosion");
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
            PlaySound(sounds[0]);
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
                score.Kill();
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
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        isDestroyed = true;
        // Destroy(gameObject);

        gameObject.SetActive(false);
        Invoke("Respawn", timeDEstroy);
    }
  
    public void EnemyFollow()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }
       
    }
    public void ChasePlayer()
    {
        throw new NotImplementedException();
    }
    void Respawn()
    {
        GameObject enemyCopy = (GameObject)Instantiate(enemyRef);
        enemyCopy.transform.position = new Vector3(Random.Range(spawPos.x - 3, spawPos.x + 3), spawPos.y, spawPos.z);
        Destroy(gameObject);
    }
}


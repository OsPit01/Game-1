
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int damage;
    public GameObject effect;
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
        Instantiate(effect, transform.position, Quaternion.identity);

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



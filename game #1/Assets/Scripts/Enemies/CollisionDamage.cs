using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage = 1;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeHit(collisionDamage);
        }
    }
}

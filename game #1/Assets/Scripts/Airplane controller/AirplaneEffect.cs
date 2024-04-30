using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneEffect : MonoBehaviour
{
    public GameObject effect;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
       
    }
}

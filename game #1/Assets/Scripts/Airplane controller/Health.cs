using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    public void ChangeHealth(int healthValue)
    {
        health += healthValue;
    }
}

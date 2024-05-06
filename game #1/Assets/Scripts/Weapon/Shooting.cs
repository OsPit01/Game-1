using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shotPos;
    public GameObject Bullet;
  
    
    void Start()
    {
        

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, shotPos.transform.position, transform.localRotation);
        }
    }
    private void FixedUpdate()
    {
       
    }
}

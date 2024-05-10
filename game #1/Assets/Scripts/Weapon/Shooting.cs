
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shooting : Sounds
{
    
    [Header("Weapons")]
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
            
            PlaySound(sounds[0]);
        }
    }
    private void FixedUpdate()
    {
       
    }
    public void TakeProjectile(GameObject bullet)
    {
        Bullet = bullet;

    }
}

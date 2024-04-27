using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector2 offSet = Vector2.zero;
    private Material material;
    void Start()
    {
        material = GetComponent<Renderer>().material;
        offSet = material.GetTextureOffset("_MainTex");
        
    }

    void Update()
    {
        offSet.x += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex",offSet);
    }
}

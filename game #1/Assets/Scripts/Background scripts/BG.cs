using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BG : MonoBehaviour
{

    void Start()
    {
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Screen.width / Screen.height;

        if (gameObject.name == "Background") {
            transform.localScale = new Vector3(width, height, 0);
            }
    }
}

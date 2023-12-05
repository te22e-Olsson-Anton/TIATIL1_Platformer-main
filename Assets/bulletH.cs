using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletH : MonoBehaviour
{
    

    public float speed = 20f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "enemy" || other.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fiende : MonoBehaviour
{
   
    
    public float moveSpeed = 5f;
    [SerializeField]
    bool moveRight = true;
    [SerializeField]
    bool moveLeft = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(moveRight == true)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if(moveLeft == true)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        /*if(other.gameObject.tag == "ground" && moveRight == true)
        {
            moveLeft = true;
            moveRight = false;
            Debug.Log("left");
        }*/
        if(other.gameObject.tag == "ground" && moveLeft == false)
        {
            moveLeft = true;
            moveRight = false;
        }
        else
        {
            moveRight = true;
            moveLeft = false;
        }

    }
}

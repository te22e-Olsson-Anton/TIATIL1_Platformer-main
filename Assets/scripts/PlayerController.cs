using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  [SerializeField]
  float speed = 5;

  [SerializeField]
  float jumpForce = 3000;

  [SerializeField]
  LayerMask groundLayer;

  [SerializeField]
  float groundRadius = 0.2f;

  Rigidbody2D rBody;
  bool hasReleasedJumpButton = true;


  [SerializeField]
  int healthCurrent;

  [SerializeField]
  int healthMax = 3;

  [SerializeField]
  Slider healthBar;

  private Vector3 checkpoint;

  void Awake()
  {
    rBody = GetComponent<Rigidbody2D>();
    
  }

  void Start ()
  {
    healthCurrent = healthMax;
    healthBar.maxValue = healthMax;
    healthBar.value = healthCurrent;

    checkpoint = new Vector3(0, 0, 0);
  }

  // Update is called once per frame
  void Update()
  {
    // Debug.DrawLine(Vector2.zero, Vector2.down * 8, Color.green);

    float moveX = Input.GetAxisRaw("Horizontal");

    Vector2 movement = new Vector2(moveX, 0) * speed * Time.deltaTime;

    transform.Translate(movement);

    // bool isGrounded = Physics2D.OverlapCircle(GetFootPosition(), groundRadius, groundLayer);
    bool isGrounded = Physics2D.OverlapBox(GetFootPosition(), GetFootSize(), 0, groundLayer);

    if (Input.GetAxisRaw("Jump") > 0 && hasReleasedJumpButton == true && isGrounded)
    {
      Debug.Log("JUMP!");
      rBody.AddForce(Vector2.up * jumpForce);
      hasReleasedJumpButton = false;
      
    }

    if (Input.GetAxisRaw("Jump") == 0)
    {
      hasReleasedJumpButton = true;
    }

    if(healthCurrent==0)
    {
      Destroy(gameObject);
    }
    
  }

  private Vector2 GetFootPosition()
  {
    float height = GetComponent<Collider2D>().bounds.size.y;
    return transform.position + Vector3.down * height / 2;
  }

  private Vector2 GetFootSize()
  {
    return new Vector2(GetComponent<Collider2D>().bounds.size.x * 0.9f, 0.1f);
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.DrawWireCube(GetFootPosition(), GetFootSize());

    // Gizmos.DrawWireSphere(GetFootPosition(), groundRadius);
    // Gizmos.DrawWireSphere(Vector2.zero, 1);
    // Gizmos.color = Color.green;
    // Gizmos.DrawWireCube(Vector2.zero, Vector2.one);
  }





  void OnTriggerEnter2D(Collider2D other) 
  {
    if(other.gameObject.tag == "enemy")
      {
        healthCurrent --;

        healthBar.value = healthCurrent;
      }


      if(other.gameObject.tag == "spike")
        {
            transform.position = checkpoint;
            healthCurrent = 3;
            healthBar.value = healthCurrent;
        }


        if(other.gameObject.tag == "checkPoint")
        {
          checkpoint = transform.position;
        }
  }
}

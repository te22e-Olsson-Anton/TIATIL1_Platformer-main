using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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

  bool right = true;
  bool left = false;


  [SerializeField]
  int healthCurrent;

  [SerializeField]
  int healthMax = 3;

  [SerializeField]
  Slider healthBar;

  private Vector3 checkpoint;

  [SerializeField]
  GameObject BulletH;
  [SerializeField]
  GameObject BulletV;

  [SerializeField]
    float timeBetweenShots = 0.5f;
    float timeSinceLastShot = 0;


    public TMP_Text timerText;
    private float startTime;
    private bool isTimerRunning;




    [SerializeField]
    public class HighscoreEntry
    {
        public float time;
    }

    public TMP_Text highscoreText;

    

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

    startTime = Time.time;
    isTimerRunning = true;

    
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
        SceneManager.LoadScene(2);
    }

    timeSinceLastShot += Time.deltaTime;

    if (Input.GetKey(KeyCode.D))
    {
      right = true;
      left = false;
    }
    if (Input.GetKey(KeyCode.A))
    {
      left = true;
      right = false;
    }

    if(Input.GetKey(KeyCode.E) && right == true && timeSinceLastShot > timeBetweenShots)
    {
        Instantiate(BulletH, transform.position, Quaternion.identity);
        timeSinceLastShot = 0;
    }
    if(Input.GetKey(KeyCode.E) && left == true && timeSinceLastShot > timeBetweenShots)
    {
      Instantiate(BulletV, transform.position, Quaternion.identity);
      timeSinceLastShot = 0;
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
            
            
        }


        if(other.gameObject.tag == "checkPoint")
        {
          checkpoint = transform.position;
        }


        if(other.gameObject.tag == "win")
        {
            SceneManager.LoadScene(3);
    
        }

  }


  

   
}

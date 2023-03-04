using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int health = 50;
    [SerializeField] private int enemyDamage = 10;
    [SerializeField] private GameObject player;   
    [SerializeField] private LayerMask groundMask;   
    [SerializeField] private Text healthText;   
    [SerializeField] private ParticleSystem doubleJumpEffect;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform playerTransform;
    private float gravity = -25f;
    private CharacterController characterController;
    private Vector3 velocity;   
    public bool canIMove;




    private void Awake()
    {
        characterController = GetComponent<CharacterController>();    
        
        Physics.IgnoreLayerCollision(8, 3);       
    }

    private void FixedUpdate()
    {

        float moveX = 0;
        float moveZ = 0;

        if (canIMove)
        {
            moveZ = Input.GetAxis("Vertical");
            
        }

        moveX = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        characterController.Move(move * Time.fixedDeltaTime * speed);                         

        velocity.y += gravity * Time.fixedDeltaTime;

        characterController.Move(velocity * Time.fixedDeltaTime);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        healthText.text = health.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            health -= enemyDamage;
            Debug.Log("У вас " + health + " Здоровья");
            Destroy(collision.gameObject);
        }
    }
}

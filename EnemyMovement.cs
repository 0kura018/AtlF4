using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int minimalSpeed;
    [SerializeField] private int maximalSpeed;
    [SerializeField] private int damage1;
    [SerializeField] private int damage2;
    [SerializeField] private int scoreGive;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] GameObject enemy;
    
    Score scoreScript = new();
    private SoundManager soundManager = new();
    public int speed;
    public int health;
    private int damage;
    public bool changeGun;

    private void Awake()
    {
        enemy.GetComponent<EnemyMovement>();
        Physics.IgnoreLayerCollision(7, 7);       
        Physics.IgnoreLayerCollision(7, 9);       
        speed = Random.Range(minimalSpeed, maximalSpeed + 1);
        if (enemyTransform.position.z > 0)
        {
            enemyTransform.Rotate(Vector3.right * 180);
            enemyTransform.Rotate(Vector3.forward * 180);
        }
        if (enemyTransform.position.y < 0)
        {
            speed = 0;
        }

    }
    private void Update()
    {
        if (health <= 0)
        {
            scoreScript.AddScore(scoreGive);
            Destroy(gameObject);
        }
        Debug.Log(damage);
    }
    private void FixedUpdate()
    {
        enemyTransform.position += enemyTransform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("goPoint"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            health -= damage1;        
        }
        else if (collision.gameObject.CompareTag("bullet1"))
        {
            Destroy(collision.gameObject);
            health -= damage2;
        }
    }
}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletLife;       
    [SerializeField] private int damage;
    [SerializeField] private bool isFirstBullet;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private GameObject destroyEffect1;
    [SerializeField] private GameObject destroyEffect2;
    [SerializeField] private GameObject destroyEffect3;
    [SerializeField] private GameObject destroyEffect4;
    [SerializeField] private GameObject destroyEffect5;
    [SerializeField] private GameObject destroyEffect6;
    [SerializeField] private GameObject destroySound;
    [SerializeField] private GameObject destroyFriendlyCarSound;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private AudioSource sound;
    [SerializeField] private Quaternion defaultQuaternion;
  
    private float timeToGetMorePoint = 0.5f;   
    public float score = 0;

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
        Physics.IgnoreLayerCollision(3, 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject destroySoundObject = Instantiate(destroySound, bulletPosition.position, default);
            Destroy(destroySoundObject, 4f);
            GameObject destroyEffectObject = Instantiate(destroyEffect, bulletPosition.position, default);
            Destroy(destroyEffectObject, 1f);

            if(timeToGetMorePoint <= 0)
            {
                score += 1;
            }
            else
            {
                score += 5;
            }

            Debug.Log("очков: " + score);

            timeToGetMorePoint = 0.5f;;          
        }
        else if (collision.gameObject.CompareTag("Enemy1"))
        {
            GameObject destroySoundObject = Instantiate(destroySound, bulletPosition.position, default);
            Destroy(destroySoundObject, 4f);
            GameObject destroyEffectObject = Instantiate(destroyEffect1, bulletPosition.position, default);
            Destroy(destroyEffectObject, 1f);

            if (timeToGetMorePoint <= 0)
            {
                score += 1;
            }
            else
            {
                score += 5;
            }

            Debug.Log("очков: " + score);

            timeToGetMorePoint = 0.5f; ;
        }
        else if (collision.gameObject.CompareTag("Enemy2"))
        {
            GameObject destroySoundObject = Instantiate(destroySound, bulletPosition.position, default);
            Destroy(destroySoundObject, 4f);
            GameObject destroyEffectObject = Instantiate(destroyEffect2, bulletPosition.position, default);
            Destroy(destroyEffectObject, 1f);

            if (timeToGetMorePoint <= 0)
            {
                score += 1;
            }
            else
            {
                score += 5;
            }

            Debug.Log("очков: " + score);

            timeToGetMorePoint = 0.5f; ;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            GameObject destroySoundObject = Instantiate(destroySound, bulletPosition.position, default);
            GameObject destroyEffectObject = Instantiate(destroyEffect4, bulletPosition.position, default);
            Destroy(destroyEffectObject, 1f);
            Destroy(destroySoundObject, 4f);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("River"))
        {
            GameObject destroySoundObject = Instantiate(destroySound, bulletPosition.position, default);
            GameObject destroyEffectObject = Instantiate(destroyEffect6, bulletPosition.position, default);
            Destroy(destroyEffectObject, 1f);
            Destroy(destroySoundObject, 4f);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("bullet") || collision.gameObject.CompareTag("bullet1"))
        {
            GameObject destroySoundObject = Instantiate(destroySound, bulletPosition.position, default);
            GameObject destroyEffectObject = Instantiate(destroyEffect3, bulletPosition.position, default);
            Destroy(destroyEffectObject, 1f);
            Destroy(destroySoundObject, 4f);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("FriendlyCar") || collision.gameObject.CompareTag("bullet") || collision.gameObject.CompareTag("bullet1"))
        {
            GameObject destroySoundObject = Instantiate(destroySound, bulletPosition.position, default);
            GameObject destroyFriendlyCarSoundObject = Instantiate(destroyFriendlyCarSound, bulletPosition.position, default);
            GameObject destroyEffectObject = Instantiate(destroyEffect3, bulletPosition.position, default);
            Destroy(destroyEffectObject, 1f);
            Destroy(destroySoundObject, 4f);
            Destroy(destroyFriendlyCarSoundObject, 2.5f);
            Destroy(gameObject);
        }
        else
        {
            GameObject destroySoundObject = Instantiate(destroySound, bulletPosition.position, default);
            GameObject destroyEffectObject = Instantiate(destroyEffect5, bulletPosition.position, default);
            Destroy(destroyEffectObject, 1f);
            Destroy(destroySoundObject, 4f);
            Destroy(gameObject);
        }                         
    }
}

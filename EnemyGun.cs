using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float shootForce;
    [SerializeField] private float startTimeBtwShoot;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject bullet; 
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private Quaternion defaultQuaternion;

    private float timeBtwShoot;
    private GameObject currentBullet;
    private void Awake()
    {
        timeBtwShoot = startTimeBtwShoot / 2;
    }
    private void Update()
    {
        if (spawnBullet.position.y < 0)
        {
            
        }
        else
        {
            if (timeBtwShoot <= 0)
            {
                Shoot();
                timeBtwShoot = startTimeBtwShoot;
            }
            else
            {
                timeBtwShoot -= Time.deltaTime;
            }
        }

        
        player = GameObject.Find("Tank");

        transform.LookAt(player.transform);         
    }
    private void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        Vector3 targetPoint;

        targetPoint = ray.GetPoint(distance);

        Vector3 dirWithOutSpread = targetPoint - spawnBullet.position;

        Vector3 dirWithSpread = dirWithOutSpread + new Vector3(0, 0, 0);

        currentBullet = Instantiate(bullet, spawnBullet.position, defaultQuaternion);      

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
    }
}

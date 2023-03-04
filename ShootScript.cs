using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private float spreed1;
    [SerializeField] private float spreed2;
    [SerializeField] private int health;
    [SerializeField] private float distance;
    [SerializeField] private float shootForce1;
    [SerializeField] private float shootForce2;
    [SerializeField] private float startTimeBtwShoot1;
    [SerializeField] private float startTimeBtwShoot2;
    [SerializeField] private float startReloadTime;
    [SerializeField] private float startCartridges1 = 10;
    [SerializeField] private float startCartridges2 = 30;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bullet1;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject weapon1;
    [SerializeField] private Text AmmoText;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private RaycastHit hit;
    [SerializeField] private Quaternion defaultQuaternion;

    public int damage1;
    public int damage2;

    private SoundManager soundManager = new();
    private float spreed;
    private float shootForce;
    private float startTimeBtwShoot;
    private float startCartridges;
    private float timeBtwShoot;
    private float reloadTime;
    private float reloadCoolDown;
    private float cartridges;
    public bool changeGun = false;
    private GameObject currentBullet;

    private void Awake()
    {
        startCartridges = startCartridges1;
        spreed = spreed1;
        shootForce = shootForce1;
        startTimeBtwShoot = startTimeBtwShoot1;
        changeGun = true;
        Physics.IgnoreLayerCollision(3, 3);
    }
    private void Update()
    {
        AmmoText.text = cartridges.ToString();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (changeGun)
            {
                startCartridges = startCartridges2;
                spreed = spreed2;
                shootForce = shootForce2;
                startTimeBtwShoot = startTimeBtwShoot2;
                reloadTime = startReloadTime;
                cartridges = 0;
                changeGun = false;
                weapon.SetActive(false);
                weapon1.SetActive(true);
            }
            else if (changeGun == false)
            {
                startCartridges = startCartridges1;
                spreed = spreed1;
                shootForce = shootForce1;
                startTimeBtwShoot = startTimeBtwShoot1;
                reloadTime = startReloadTime;
                cartridges = 0;
                changeGun = true;
                weapon.SetActive(true);
                weapon1.SetActive(false);
            }
        }

        if (cartridges > 0)
        {          
            if (timeBtwShoot <= 0)
            {
                if (Input.GetMouseButton(0) || Input.GetButtonDown("Jump"))
                {
                    Shoot();
                    timeBtwShoot = startTimeBtwShoot;
                }
            }
            else
            {
                timeBtwShoot -= Time.deltaTime;
            }

        }
        else if (cartridges <= 0)
        {                     
            if (reloadTime <= 0)
            {
                Reload();
                reloadTime = startReloadTime;
                timeBtwShoot = 0;
                soundManager.playReloadSound();
                Debug.Log(cartridges);
            }
            else
            {               
                reloadTime -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(reloadCoolDown <= 0)
            {
                cartridges = 0;
                reloadCoolDown = 6;
            }                      
        }
        else
        {
            reloadCoolDown -= Time.deltaTime;
        }        
    }

    private void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        Vector3 targetPoint;

            targetPoint = ray.GetPoint(distance);

        Vector3 dirWithOutSpread = targetPoint - spawnBullet.position;

        float x = Random.Range(-spreed, spreed);
        float y = Random.Range(-spreed, spreed);

        Vector3 dirWithSpread = dirWithOutSpread + new Vector3(y, 0, 0);

        if (changeGun)
        {
            currentBullet = Instantiate(bullet, spawnBullet.position, defaultQuaternion);
        }
        else
        {
            currentBullet = Instantiate(bullet1, spawnBullet.position, defaultQuaternion);
        }

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);

        cartridges -= 1;

        if (changeGun)
        {
            soundManager.playShoot1Sound();
        }
        else
        {
            soundManager.playShoot2Sound();
        }

        Debug.Log(cartridges);               
    }
    private void Reload()
    {
        cartridges = startCartridges;
    }

}

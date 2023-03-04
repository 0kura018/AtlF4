using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 20;
    public float fireRate = 1f;
    public ParticleSystem muzzleFlash;
    public AudioClip shotSFX;
    public AudioSource _audioSource;
    public float range = 15;
    public Transform bulletSpawn;
    public float force;
    public GameObject hitEffect; 
    public GameObject bullet;

    public Camera _cam;

    private float nextFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    private void Shoot()
    {
        _audioSource.PlayOneShot(shotSFX);
        muzzleFlash.Play();

        RaycastHit hit;

        if(Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, range))
        {
            Debug.Log("WHFHHFH " + hit.collider);
            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            impact.tag = "Hit";
            Destroy(impact, 2f);

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }
}

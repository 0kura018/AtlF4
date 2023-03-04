using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform spawnPointPosition;
    [SerializeField] private Transform spawnPointPosition1;
    [SerializeField] private Quaternion spawnPointQuaternion;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject friend;
    [SerializeField] private GameObject friend1;
    [SerializeField] private float startTimeBtwSpawn;
    [SerializeField] private int defaultCarSpawnRate = 70;

    private float timeBtwSpawn = 0;
    private int spawnPointNumber = 0;

    private void Awake()
    {
        timeBtwSpawn = (startTimeBtwSpawn + Random.Range(0, 6)) / 2;
    }
    private void FixedUpdate()
    {
        if (timeBtwSpawn <= 0)
        {
            spawnPointNumber = Random.Range(1, 3);
            timeBtwSpawn = startTimeBtwSpawn + Random.Range(0, 6);            
            spawnEnemyOnGame();
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;       
        }
    }

    private void spawnEnemyOnGame()
    {
        int howCar = Random.Range(1, 122);
        if (howCar  <= defaultCarSpawnRate)
        {
            if (spawnPointNumber == 1)
            {
                GameObject enemySpawn = Instantiate(enemy, spawnPointPosition.position, spawnPointQuaternion);
            }
            else if (spawnPointNumber == 2)
            {
                GameObject enemySpawn = Instantiate(enemy, spawnPointPosition1.position, spawnPointQuaternion);
            }
        }
        else if (howCar > defaultCarSpawnRate && howCar <= 100)
        {
            if (spawnPointNumber == 1)
            {
                GameObject enemySpawn = Instantiate(enemy1, spawnPointPosition.position, spawnPointQuaternion);
            }
            else if (spawnPointNumber == 2)
            {
                GameObject enemySpawn = Instantiate(enemy1, spawnPointPosition1.position, spawnPointQuaternion);
            }
        }
        else if (howCar > 110)
        {
            if (spawnPointNumber == 1)
            {
                GameObject enemySpawn = Instantiate(friend, spawnPointPosition.position, spawnPointQuaternion);
            }
            else if (spawnPointNumber == 2)
            {
                GameObject enemySpawn = Instantiate(friend, spawnPointPosition1.position, spawnPointQuaternion);
            }
        }
        else if (howCar > 100 && howCar < 110)
        {
            if (spawnPointNumber == 1)
            {
                GameObject enemySpawn = Instantiate(friend1, spawnPointPosition.position, spawnPointQuaternion);
            }
            else if (spawnPointNumber == 2)
            {
                GameObject enemySpawn = Instantiate(friend1, spawnPointPosition1.position, spawnPointQuaternion);
            }
        }
    }
}

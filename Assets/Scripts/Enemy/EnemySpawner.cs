using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public Transform Player;
    public int NumberOfEnemiesToSpawn = 5;
    public float SpawnDelay = 1f;
    public Enemy EnemyPrefab;

    private ObjectPool<Enemy> enemyPool;
    private Coroutine spawnCoroutine;

    private void Awake()
    {
        enemyPool = new ObjectPool<Enemy>(
            () =>
        {
            return Instantiate(EnemyPrefab);
        }, 
            enemy =>
        {
            enemy.gameObject.SetActive(true);
        }, 
            enemy =>
        {
            enemy.gameObject.SetActive(false);
        }, 
            enemy =>
        {
            Destroy(enemy);
        }, false, 100, 200);
    }

    private void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {      
        while (true)
        {
            yield return new WaitForSeconds(3);

            var enemy = enemyPool.Get();
            enemy.transform.position = Player.position + Random.insideUnitSphere * 10;
            enemy.Init(Player);
        }       
    }
}

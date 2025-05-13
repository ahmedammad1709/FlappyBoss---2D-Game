using UnityEngine;

public class BambooSpawner : MonoBehaviour
{
    public GameObject bambooPrefab;     
    public float spawnInterval = 1.5f;  
    public float moveSpeed = 1.4f;      
    public float minY = 2.5f;          
    public float maxY = 7.5f;      
    //public bool isGameOver = false;

    void Start()
    {
        InvokeRepeating("SpawnBamboo", 1f, spawnInterval);
    }

    void SpawnBamboo()
    {
        //if (isGameOver) return;

        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 88f);

        GameObject bamboo = Instantiate(bambooPrefab, spawnPosition, Quaternion.identity);
        bamboo.AddComponent<BambooMover>().moveSpeed = moveSpeed;
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnBamboo");
        //isGameOver = true;

    }



}

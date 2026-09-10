using System.Collections;
using UnityEngine;

public class spawnObstacles : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject obstaclePrefab;

    private readonly float objectKillTime = 5;

    // Interactive variables depending on playerPos (changing within gameplay)
    public float pushPower = 20;
    private Vector3 spawnPos = new(-11, 4, -6);
    private Vector3 secondSpawnPos = new(-11, 4, -35); // Spawn position is prepared for the next obstacle

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    // Position of player is consistently checked by the reoccuring coroutine, upon reaching one of the defined barrier points, objects are spawned

    IEnumerator SpawnObstacles()
    {
        Debug.Log("Get Ready!");
        yield return new WaitUntil(() => playerObj.transform.position.z <= -3);
        SpawnObstacle();

        yield return new WaitUntil(() => playerObj.transform.position.z <= -30);
        spawnPos = secondSpawnPos;
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        Debug.Log("Oh shit! Watch out! ");
        GameObject prefab = Instantiate(obstaclePrefab, spawnPos, transform.rotation);
        Rigidbody prefabRb = prefab.GetComponent<Rigidbody>();
        prefabRb.AddForce(Vector3.right * pushPower, ForceMode.Impulse);
        Destroy(prefab, objectKillTime);
    }
}

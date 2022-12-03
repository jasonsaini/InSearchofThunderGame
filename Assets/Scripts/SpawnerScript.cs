using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public MeshCollider playArea;
    RandomPointInCollider spawnPoint;
    [SerializeField] private GameObject enemy1;

    public bool spawnSomething = false;
    // Start is called before the first frame update
    void Start()
    {
        playArea = GetComponent<MeshCollider>();
        spawnPoint = new RandomPointInCollider(playArea);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnSomething == true) {
            Instantiate(enemy1, spawnPoint.RandomPoint(), Quaternion.identity);
            spawnSomething = false;
            Debug.Log("Spawned something!");
        }
    }

}

public class RandomPointInCollider {
    MeshCollider collider;
    Vector3 minBound;
    Vector3 maxBound;

    int layerMask = 1 << 9;

    public RandomPointInCollider(MeshCollider collider) {
        this.collider = collider;
        this.minBound = collider.bounds.min;
        this.maxBound = collider.bounds.max;
    }

    public Vector3 RandomPoint() {
        Vector3 randomPoint;

        do {
            randomPoint =
              new Vector3(
                Random.Range(minBound.x, maxBound.x),
                0.1f,
                Random.Range(minBound.z, maxBound.z)
              );
        } while (!Physics.Raycast(randomPoint, Vector3.down, 1f, layerMask));

        return randomPoint;
    }
}
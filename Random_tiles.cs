using UnityEngine;

public class RandomTerrainSpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public Terrain terrain; // Reference to the terrain
    public int numberOfObjects = 100; // Number of objects to spawn

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Get a random position within the terrain bounds
            float x = Random.Range(0, terrain.terrainData.size.x);
            float z = Random.Range(0, terrain.terrainData.size.z);
            float y = terrain.SampleHeight(new Vector3(x, 0, z)); // Sample the height of the terrain

            // Create the object at the random position
            Vector3 spawnPosition = new Vector3(x, y, z);

            Instantiate(prefab, spawnPosition, Quaternion.identity);
            float xa = Random.Range(0, terrain.terrainData.size.x);
            float za = Random.Range(0, terrain.terrainData.size.z);
            float ya = terrain.SampleHeight(new Vector3(x, 0, z)); // Sample the height of the terrain

            // Create the object at the random position
            Vector3 spawnPositions = new Vector3(xa, ya, za);
            Instantiate(prefab1, spawnPositions, Quaternion.identity);

            float xc = Random.Range(0, terrain.terrainData.size.x);
            float zc = Random.Range(0, terrain.terrainData.size.z);
            float yc = terrain.SampleHeight(new Vector3(x, 0, z)); // Sample the height of the terrain

            // Create the object at the random position
            Vector3 spawnPositionss = new Vector3(xc, yc, zc);
            Instantiate(prefab2, spawnPositionss, Quaternion.identity);

            float xv = Random.Range(0, terrain.terrainData.size.x);
            float zv = Random.Range(0, terrain.terrainData.size.z);
            float yv = terrain.SampleHeight(new Vector3(x, 0, z)); // Sample the height of the terrain

            // Create the object at the random position
            Vector3 spawnPositionsss = new Vector3(xv, yv, zv);
            Instantiate(prefab3, spawnPositionsss, Quaternion.identity);
        }
    }
}

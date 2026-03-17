using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject survivorPrefab;
    public GameObject waterPrefab;   // optional water supply
    public Transform spawnPoint;     // position of the window

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        // Wave 1 - 1 survivor
        SpawnSurvivor(survivorPrefab);
        yield return new WaitForSeconds(1.4f);
        if (waterPrefab != null)
            SpawnSurvivor(waterPrefab); // 1st water
        yield return new WaitForSeconds(18f);

        // Wave 2 - 2 survivors + 1 water
        SpawnSurvivor(survivorPrefab);
        yield return new WaitForSeconds(1.4f);
        SpawnSurvivor(survivorPrefab);
        yield return new WaitForSeconds(1.4f);
        if (waterPrefab != null)
            SpawnSurvivor(waterPrefab); // 2nd water
        yield return new WaitForSeconds(16f);


        // Wave 3 - 3 survivors + 1 water
        SpawnSurvivor(survivorPrefab);
        yield return new WaitForSeconds(1.2f);
        SpawnSurvivor(survivorPrefab);
        yield return new WaitForSeconds(1f);
        SpawnSurvivor(survivorPrefab);
        yield return new WaitForSeconds(1f);
        if (waterPrefab != null)
            SpawnSurvivor(waterPrefab); // 3rd water
        yield return new WaitForSeconds(16f);

        // Wave 4 - 2 survivors + 1 water
        // SpawnSurvivor(survivorPrefab);
        // yield return new WaitForSeconds(1.2f);
        // SpawnSurvivor(survivorPrefab);
        // yield return new WaitForSeconds(1.2f);
        // if (waterPrefab != null)
        //     SpawnSurvivor(waterPrefab); // 2nd water
        // yield return new WaitForSeconds(16f);

        // // Wave 5 - 2 survivors
        // SpawnSurvivor(survivorPrefab);
        // yield return new WaitForSeconds(1.2f);
        // SpawnSurvivor(survivorPrefab);

        // Optional: spawn a water supply randomly
        // yield return new WaitForSeconds(14f);
        // if (waterPrefab != null)
        //     SpawnSurvivor(waterPrefab);
    }

    void SpawnSurvivor(GameObject prefab)
    {
        GameObject survivor = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        // Assign UIManager automatically
        Survivor s = survivor.GetComponent<Survivor>();
        if (s != null)
            s.uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();


        Rigidbody2D rb = survivor.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // initial jump toward trampoline
            float initialX = Random.Range(1.5f, 3f);
            float initialY = Random.Range(4.5f, 6f);
            //float initialX = Random.Range(1.5f, 3f); // slower horizontal
            //float initialY = Random.Range(4.5f, 6f); // lower vertica
            StartCoroutine(LaunchAfterDelay(rb, initialX, initialY));
        }
    }

    IEnumerator LaunchAfterDelay(Rigidbody2D rb, float x, float y)
    {
        yield return new WaitForSeconds(0.1f);
        rb.linearVelocity = new Vector2(x, y);
    }

}

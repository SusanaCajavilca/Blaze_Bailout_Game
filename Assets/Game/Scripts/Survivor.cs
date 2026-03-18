using UnityEngine;

public class Survivor : MonoBehaviour
{
    public UIManager uiManager;
    public GameObject waterBeamPrefab; // Assign your water beam prefab here
    public float waterBeamOffsetX = 10f; // X offset to spawn the beam at the right side

    void OnTriggerEnter2D(Collider2D other)
    {
        if (uiManager == null)
        {
            Debug.LogWarning("UIManager not assigned on Survivor prefab!");
            return;
        }

        // When reaching SafeZone
        if (other.CompareTag("SafeZone"))
        {
            if (CompareTag("Survivor"))
            {
                // Increment rescued counter
                uiManager.IncrementRescued();
            }
            else if (CompareTag("Water"))
            {
                // Add time to timer
                Timer timer = FindFirstObjectByType<Timer>();
                if (timer != null)
                    timer.AddTime(20f);

                // Spawn water beam effect
                if (waterBeamPrefab != null)
                {
                    Vector3 spawnPos = new Vector3(
                        Camera.main.transform.position.x + waterBeamOffsetX, // right edge
                        transform.position.y,                               // same Y as water
                        0f
                    );
                    Instantiate(waterBeamPrefab, spawnPos, Quaternion.identity);
                }
            }

            // Destroy the survivor or water supply after triggering
            Destroy(gameObject);
        }
        // When falling into FireZone
        else if (other.CompareTag("FireZone"))
        {
            if (CompareTag("Survivor"))
            {
                uiManager.IncrementLost();
            }

            Destroy(gameObject);
        }
    }
}

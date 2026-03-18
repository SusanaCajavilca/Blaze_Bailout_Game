using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    public float moveSpeed = 8f;

    // Set limits to the trampoline
    public float xMin = -14f; // left limit
    public float xMax = 14f;  // right limit

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        Vector3 position = transform.position;
        position.x += move * moveSpeed * Time.deltaTime;

        // Clamp position so it stays between xMin and xMax
        position.x = Mathf.Clamp(position.x, xMin, xMax);

        transform.position = position;
    }
}

using UnityEngine;

public class TrampolineBounce : MonoBehaviour
{
    public float bounceForce = 11f;       // upward velocity

    public float horizontalMin = 1.8f;    // min horizontal push toward right (toward safe zone)
    public float horizontalMax = 3f;      // max horizontal push toward right (toward safe zone)

    public AudioSource jumpSound; // reference to the AudioSource

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Survivor") || collision.gameObject.CompareTag("Water"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Add slight random horizontal push toward safe zone
                float horizontalFactor = Random.Range(horizontalMin, horizontalMax);
                rb.linearVelocity = new Vector2(horizontalFactor, bounceForce);

                // Play jump sound
                if (jumpSound != null && collision.gameObject.CompareTag("Survivor"))
                    jumpSound.Play();
            }
        }
    }
}

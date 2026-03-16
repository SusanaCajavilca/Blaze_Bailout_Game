using UnityEngine;

public class WaterBeamController : MonoBehaviour
{

    public float speed = 10f;          // pixels per second
    public float lifetime = 3f;        // destroy after it moves off screen

    void Start()
    {
        Destroy(gameObject, lifetime); // auto-remove after lifetime
    }

    void Update()
    {
        // Move left every frame
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Optional: destroy after leaving screen
        if (transform.position.x < -20f)
            Destroy(gameObject);
    }


}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;      // trampoline
    public float xMin, xMax;      // level bounds
    public float yFixed = 0f;     // fixed vertical position

    void LateUpdate()
    {
        if (target != null)
        {
            float x = Mathf.Clamp(target.position.x, xMin, xMax);
            transform.position = new Vector3(x, yFixed, transform.position.z);
        }
    }

}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerInputSystem : MonoBehaviour
{
    [Header("Input")]
    public InputActionReference moveAction; // assign Move action from .inputactions

    [Header("Movement")]
    public float moveSpeed = 6f;

    [Header("References")]
    public Animator animator; // assign or leave empty to auto-find

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        if (animator == null) animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void OnEnable()
    {
        if (moveAction != null) moveAction.action.Enable();
    }

    void OnDisable()
    {
        if (moveAction != null) moveAction.action.Disable();
    }

    void Update()
    {
        if (moveAction == null) return;

        Vector2 input = moveAction.action.ReadValue<Vector2>(); // x = left/right, y = up/down if any
        float x = input.x;

        // Move the player horizontally (side-view)
        transform.Translate(new Vector3(x, 0f, 0f) * moveSpeed * Time.deltaTime);

        // Drive animator - use a float parameter "Speed" (abs x)
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(x));
        }

        // Flip sprite (assumes flipping by SpriteRenderer.flipX)
        if (spriteRenderer != null && x != 0f)
        {
            if (x > 0.01f)
                transform.localScale = new Vector3(1, 1, 1);
            else if (x < -0.01f)
                transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction LeftAction;
    public InputAction RightAction;
    public InputAction JumpAction;
    private Rigidbody2D PlayerRigidBody2D;
    private BoxCollider2D PlayerBoxCollider2D;
    [SerializeField] private LayerMask PlatformsLayerMask;
    void Start()
    {
        LeftAction.Enable();
        RightAction.Enable();
        JumpAction.Enable();

        PlayerRigidBody2D = GetComponent<Rigidbody2D>();
        PlayerBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float horizontal = 0.0f;
        float vertical = 0.0f;
        GameObject playerSquareGameObject = gameObject.transform.Find("Square").gameObject;
        SpriteRenderer playerSpriteRenderer = playerSquareGameObject.GetComponent<SpriteRenderer>();

        if (LeftAction.IsPressed())
        {
            horizontal = -1.0f;
            playerSpriteRenderer.flipX = false;
        }
        else if (RightAction.IsPressed())
        {
            horizontal = 1.0f;
            playerSpriteRenderer.flipX = true;
        }

        Vector2 position = transform.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 0.1f * vertical;
        transform.position = position;

        if (JumpAction.IsPressed() && IsGrounded())
        {
            float jumpVelocity = 25.0f;
            PlayerRigidBody2D.linearVelocity = Vector2.up * jumpVelocity;
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D rayCastHit2D = Physics2D.BoxCast(PlayerBoxCollider2D.bounds.center, PlayerBoxCollider2D.bounds.size, 0.0f, Vector2.down, 0.1f, PlatformsLayerMask);
        return rayCastHit2D.collider != null;
    }
}

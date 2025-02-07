using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction LeftAction;
    public InputAction RightAction;

    void Start()
    {
        LeftAction.Enable();
        RightAction.Enable();
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
        Debug.Log(horizontal);

        Vector2 position = transform.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 0.1f * vertical;
        transform.position = position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Sprite[] directionSprites; // 0: Bas, 1: Bas-Gauche, 2: Gauche, 3: Haut-Gauche, 4: Haut, 5: Haut-Droite, 6: Droite, 7: Bas-Droite

    private Vector2 movement;

    void Update()
    {


        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = movement.normalized * moveSpeed;

        if (movement != Vector2.zero)
        {
            UpdateSpriteDirection(movement);
        }
    }

    void UpdateSpriteDirection(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle < 0) angle += 360;

        int index = 0;

        if (angle >= 337.5f || angle < 22.5f)
            index = 6; // Droite
        else if (angle >= 22.5f && angle < 67.5f)
            index = 7; // Bas-Droite
        else if (angle >= 67.5f && angle < 112.5f)
            index = 0; // Bas
        else if (angle >= 112.5f && angle < 157.5f)
            index = 1; // Bas-Gauche
        else if (angle >= 157.5f && angle < 202.5f)
            index = 2; // Gauche
        else if (angle >= 202.5f && angle < 247.5f)
            index = 3; // Haut-Gauche
        else if (angle >= 247.5f && angle < 292.5f)
            index = 4; // Haut
        else if (angle >= 292.5f && angle < 337.5f)
            index = 5; // Haut-Droite

        spriteRenderer.sprite = directionSprites[index];
    }
}

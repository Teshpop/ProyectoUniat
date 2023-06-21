using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public float movementSpeed = 5f;
    public float chaseRadius = 10f;
    public bool canMoveB = true;

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRadius)
        {
            LookAtPlayer();

            // Mueve el objeto hacia la posición del jugador
            if (canMoveB)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
            }
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.x *= -1f;

        if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            isFlipped = true;
        }
        else if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            isFlipped = false;
        }
    }
}


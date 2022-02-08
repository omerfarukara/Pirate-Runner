using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHorizontalMovement
{
    Transform _playerTransform;

    public EnemiesHorizontalMovement(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    public void HorizontalMove(float horizontalSpeed)
    {
        _playerTransform.Translate(Vector2.left * horizontalSpeed * Time.deltaTime);
    }
}

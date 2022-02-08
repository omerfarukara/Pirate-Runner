using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAction
{

    int jumpCount;
    int maxJumpCount = 2;

    Rigidbody2D _playerRigidbody;

    public JumpAction(Rigidbody2D playerRigidbody,OnGround onGround)
    {
        _playerRigidbody = playerRigidbody;
    }

    public void JumpClick(float forcePower)
    {
        jumpCount++;
        if (GameManager.Instance.OnGround.IsOnGround || GameManager.Instance.OnGround.IsOnStepGround)
        {
            jumpCount = 0;
        }

        if (jumpCount == 0 && !GameManager.Instance.OnGround.IsOnGround) return;
        if (jumpCount >= maxJumpCount) return;
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, forcePower);
    }
}

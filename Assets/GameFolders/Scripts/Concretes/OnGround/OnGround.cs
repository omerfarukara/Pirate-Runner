using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] Transform translate;

    bool _isOnGround;
    bool _isOnStepGround;

    public bool IsOnGround
    {
        get
        {
            return _isOnGround;
        }
        set
        {
            _isOnGround = value;
        }
    }
    public bool IsOnStepGround
    {
        get
        {
            return _isOnStepGround;
        }
        set
        {
            _isOnStepGround = value;
        }
    }

    void Update()
    {
        CheckFootOnGround(translate);
    }

    public void CheckFootOnGround(Transform footTransform)
    {
        RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, maxDistance);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag(Constants.Tags.GROUND))
            {
                IsOnGround = true;
                IsOnStepGround = false;
            }
            else if (hit.collider.CompareTag(Constants.Tags.STEP_GROUND))
            {
                IsOnStepGround = true;
                IsOnGround = false;
            }
        }
        else
        {
            IsOnGround = false;
            IsOnStepGround = false;
        }
    }
}

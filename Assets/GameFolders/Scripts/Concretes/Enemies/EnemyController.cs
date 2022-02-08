using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] float attackRayDistance;
    [SerializeField] float slowDownCoefficient;

    EnemiesHorizontalMovement _enemiesHorizontalMovement;
    Animator _animator;


    bool onAttack;

    private void Awake()
    {
        _enemiesHorizontalMovement = new EnemiesHorizontalMovement(transform);
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.Instance.GameController.NextStageForEnemy += NextStage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ResetBorder")
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        _enemiesHorizontalMovement.HorizontalMove(horizontalSpeed);
        CheckTargetDistance();
        if (onAttack)
        {
            if (horizontalSpeed > 0)
            {
                horizontalSpeed -= slowDownCoefficient * Time.deltaTime;
            }
            else
            {
                horizontalSpeed = 0;
            }
        }
    }

    void CheckTargetDistance()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, attackRayDistance, LayerMask.GetMask("Player"));
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag(Constants.Tags.PLAYER))
            {
                onAttack = true;
                _animator.SetTrigger(Constants.AnimationsTag.ATTACK);
                onAttack = false;
            }
        }
    }

    void NextStage(float newSpeed)
    {
        horizontalSpeed += newSpeed;
    }

}

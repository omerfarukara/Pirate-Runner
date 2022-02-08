using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float stepSpeedIncrease;
    [SerializeField] float enemySpeedIncrease;
    [SerializeField] int stageCoefficient;

    public event Stage NextStageForStep;
    public event Stage NextStageForEnemy;

    bool maxSpeedReached;

    float _timer = 1;
    int _currentTime = 1;

    public float Timer
    {
        get
        {
            return _timer;
        }
        set
        {
            _timer = value;

            if (maxSpeedReached) return;

            if (_currentTime != (int)_timer)
            {
                _currentTime = (int)_timer;

                if (_currentTime % stageCoefficient == 0)
                {
                    NextStageForStep?.Invoke(stepSpeedIncrease);
                    NextStageForEnemy?.Invoke(enemySpeedIncrease);
                }
            }
        }
    }

    public bool MaxSpeedReached
    {
        get { return maxSpeedReached; }
        set { maxSpeedReached = value; }
    }

    void Start()
    {
        GameManager.Instance.GameController = this;
        GameManager.Instance.PlayerController = GameObject.FindGameObjectWithTag(Constants.Tags.PLAYER).GetComponent<PlayerController>();
        GameManager.Instance.OnGround = GameObject.FindGameObjectWithTag(Constants.Tags.PLAYER).GetComponent<OnGround>();
        GameManager.Instance.Gun = GameObject.FindGameObjectWithTag(Constants.Tags.PLAYER_GUN).GetComponent<Gun>();
        GameManager.Instance.EnemyPooling = GameObject.FindGameObjectWithTag(Constants.Tags.ENEMY_POOLING).GetComponent<EnemyPooling>();
        GameManager.Instance.StepPooling = GameObject.FindGameObjectWithTag(Constants.Tags.STEP_GROUND).GetComponent<StepPooling>();
        //UIManager.Instance.ScoreUpdate();
    }

    private void Update()
    {
        Timer += Time.deltaTime;
    }
}

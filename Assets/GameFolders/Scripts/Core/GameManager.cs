using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Stage(float speed);

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    int _gold;

    bool _isGameOver;

    PlayerController _playerController;
    EnemyPooling _enemiyPooling;
    StepPooling _stepPooling;
    OnGround _onGround;
    Gun _gun;
    GameController _gameController;

    public bool IsGameOver
    {
        get
        {
            return _isGameOver;
        }

        set
        {
            _isGameOver = value;
            if (!value)
            {
                Gold = 0;
            }
        }
    }

    public PlayerController PlayerController
    {
        get
        { 
            return _playerController;
        }
        set
        {
            _playerController = value;
        }
    }

    public OnGround OnGround
    {
        get
        {
            return _onGround;
        }
        set
        {
            _onGround = value;
        }
    }

    public Gun Gun
    {
        get
        {
            return _gun;
        }
        set
        {
            _gun = value;
        }
    }

    public EnemyPooling EnemyPooling
    {
        get
        {
            return _enemiyPooling;
        }
        set
        {
            _enemiyPooling = value;
        }
    }

    public StepPooling StepPooling
    {
        get
        {
            return _stepPooling;
        }
        set
        {
            _stepPooling = value;
        }
    }

    public int Gold
    {
        get => _gold;
        set
        {
            _gold = value;
            if (value == 0) return;
            UIManager.Instance.ScoreUpdate();
        }
    }

    public int HighGold
    {
        get => PlayerPrefs.GetInt(Constants.Prefs.GOLD);
        set
        {
            PlayerPrefs.SetInt(Constants.Prefs.GOLD, value);
        }
    }

    public GameController GameController
    {
        get
        {
            return _gameController;
        }
        set
        {
            _gameController = value;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void CheckHighGold()
    {
        if (HighGold < Gold)
        {
            HighGold = Gold;
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
        _enemiyPooling.DeactiveEnemies();
        _stepPooling.DeactiveSteps();
        CheckHighGold();
        UIManager.Instance.HighScorePassed();
        UIManager.Instance.ScoreUpdate();
        UIManager.Instance.PanelControl();
    }
}

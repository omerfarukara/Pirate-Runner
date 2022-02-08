using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;

    [Header("---Spawn---")]

    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;
    [SerializeField] Vector3 enemySpawnLocation;

    bool _isFull = true;
    int _currentIndex;
    float _currentSpawnTime;

    private void Awake()
    {
        foreach (GameObject enemy in enemys)
        {
            enemy.SetActive(false);
        }
    }

    void Start()
    {
        _currentIndex = Random.Range(0, enemys.Length);

        _currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver) return;

        _currentSpawnTime -= Time.deltaTime;
        if (_currentSpawnTime <= 0)
        {
            EnemySpawn();

            _currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }



    void EnemySpawn()
    {
        _isFull = true;
        foreach (GameObject controlEnemy in enemys)
        {
            if (controlEnemy.activeInHierarchy) return;
            else
            {
                _isFull = false;
                break;
            }
        }

        if (_isFull) return;

        while (enemys[_currentIndex].activeInHierarchy)
        {
            _currentIndex = Random.Range(0, enemys.Length);
        }
        enemys[_currentIndex].transform.localPosition = enemySpawnLocation;
        enemys[_currentIndex].SetActive(true);

        _currentIndex = Random.Range(0, enemys.Length);

    }

    public void DeactiveEnemies()
    {
        foreach (GameObject enemy in enemys)
        {
            enemy.SetActive(false);
        }
    }
}

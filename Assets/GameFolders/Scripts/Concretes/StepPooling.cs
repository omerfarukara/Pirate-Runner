using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPooling : MonoBehaviour
{
    [SerializeField] GameObject[] steps;

    [Header("---Spawn Time---")]

    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;

    [Header("---Spawn Position Y---")]
    [SerializeField] float minSpawnPosY;
    [SerializeField] float maxSpawnPosY;

    bool _isFull = true;
    int _currentIndex;
    float _currentSpawnTime;

    private void Awake()
    {
        foreach (GameObject step in steps)
        {
            step.SetActive(false);
        }
    }

    private void Start()
    {
        _currentIndex = Random.Range(0, steps.Length);
        _currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver) return;

        _currentSpawnTime -= Time.deltaTime;
        if (_currentSpawnTime <= 0)
        {
            StepSpawn();

            _currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    void StepSpawn()
    {
        _isFull = true;
        foreach (GameObject controlStep in steps)
        {
            if (controlStep.activeInHierarchy) return;
            else
            {
                _isFull = false;
                break;
            }
        }

        if (_isFull) return;

        while (steps[_currentIndex].activeInHierarchy)
        {
            _currentIndex = Random.Range(0, steps.Length);
        }
        steps[_currentIndex].transform.localPosition = new Vector3(24, Random.Range(minSpawnPosY, maxSpawnPosY), 0);
        steps[_currentIndex].SetActive(true);
        _currentIndex = Random.Range(0, steps.Length);
    }

    public void DeactiveSteps()
    {
        foreach (GameObject step in steps)
        {
            step.SetActive(false);
        }
    }
}

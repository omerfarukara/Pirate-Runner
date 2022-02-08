using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] GameObject bomb;

    private void OnEnable()
    {
        bomb.SetActive(true);
    }

    private void Start()
    {
        GameManager.Instance.GameController.NextStageForStep += NextStage;
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
        transform.localPosition += Vector3.left * speed;
    }

    void NextStage(float newSpeed)
    {
        speed += newSpeed;
        if (maxSpeed <= speed)
        {
            GameManager.Instance.GameController.MaxSpeedReached = true;
        }
    }
}

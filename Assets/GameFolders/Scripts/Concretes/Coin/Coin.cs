using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] RectTransform goldRefTransform;

  //  RectTransform refGoldTransform;

    float randomt;

    bool _isCollected;

    public bool IsCollected => _isCollected;

    private void Awake()
    {
     //   refGoldTransform = UIManager.Instance.GoldRefTransform;
    }

    

    private void OnEnable()
    {
        randomt = Random.Range(0.01f, 0.04f);
        _isCollected = false;
        StartCoroutine(CoinLerpCoroutine());
    }


    IEnumerator CoinLerpCoroutine()
    {
        float t = 1;
        while (t > 0)
        {
            t -= Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, goldRefTransform.position, randomt);
            yield return null;
        }
        _isCollected = true;
        GameManager.Instance.Gold++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float maxHealt;
    [SerializeField] float healtDecreaseTime;
    [SerializeField] [Range(0, 1)] float decreaseCoefficient;
    [SerializeField] float forcePower;

    JumpAction _jumpAction;

    Vector2 newAnchor;
    float _healt;
    bool onDamageCoroutine;

    public float Healt
    {
        get
        {
            return _healt;
        }
        set
        {
            _healt = value;
            newAnchor = new Vector2(_healt / maxHealt, UIManager.Instance.HealtImage.anchorMax.y);
            if (!onDamageCoroutine)
            {
                StartCoroutine(DamageCoroutine(healtDecreaseTime));
            }
            if (value <= 0)
            {
                _healt = 0;
                Dead();
            }
        }
    }

    private void Awake()
    {
        _jumpAction = new JumpAction(GetComponent<Rigidbody2D>(), GetComponent<OnGround>());
    }

    private void Start()
    {
        _healt = maxHealt;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.Tags.BOMB))
        {
            Healt = 0;
        }
    }

    void Dead()
    {
        GameManager.Instance.GameOver();
        gameObject.SetActive(false);
    }

    public void Jump()
    {
        _jumpAction.JumpClick(forcePower);
    }

    IEnumerator DamageCoroutine(float delay)
    {
        onDamageCoroutine = true;
        while (delay > 0)
        {
            delay -= Time.deltaTime;
            UIManager.Instance.HealtImage.anchorMax = Vector2.Lerp(UIManager.Instance.HealtImage.anchorMax, newAnchor, decreaseCoefficient);
            yield return null;
        }

        UIManager.Instance.HealtImage.anchorMax = new Vector2(_healt / maxHealt, UIManager.Instance.HealtImage.anchorMax.y);
        onDamageCoroutine = false;
    }
}
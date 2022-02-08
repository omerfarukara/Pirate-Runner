using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.Tags.BOMB))
        {
            GameManager.Instance.Gold++;
            collision.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.Tags.ENEMIES))
        {
            Destroy(this.gameObject);
            GameManager.Instance.Gold++;
            collision.gameObject.SetActive(false);
        }
        if (collision != null)
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        _rigidbody.velocity = transform.right * speed;
    }
}

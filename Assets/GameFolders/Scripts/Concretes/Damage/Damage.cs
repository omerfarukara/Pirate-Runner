using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Constants.Tags.PLAYER)
        {            
            collision.gameObject.GetComponent<PlayerController>().Healt -= damage;
            transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}

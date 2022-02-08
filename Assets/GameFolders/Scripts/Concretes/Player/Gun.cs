using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Joystick _joystick;
    [SerializeField] float angleRange;

    public GameObject _stick;

    private void Start()
    {
        _stick.SetActive(false);
    }

    public void GunRotate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _joystick.Vertical * angleRange);
    }
}

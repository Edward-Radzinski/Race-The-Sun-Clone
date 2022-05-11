using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acceleration : MonoBehaviour
{
    [SerializeField] private GameObject _leftBtn, _rightBtn;
    private bool _accelerator = false;
    private float _sensitivity = 1;

    private void Update()
    {
        _accelerator = System.Convert.ToBoolean(PlayerPrefs.GetFloat("Accelerator"));
        _sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        ChangesType();
        if (_accelerator)
        {
            Ship.Instance.hMove = Input.acceleration.x * _sensitivity;
            Ship.Instance.hMove = Mathf.Clamp(Ship.Instance.hMove, -1, 1);
        }
    }

    private void ChangesType()
    {
        if (_accelerator)
        {
            _leftBtn.SetActive(false);
            _rightBtn.SetActive(false);
        }
        else
        {
            _leftBtn.SetActive(true);
            _rightBtn.SetActive(true);
        }
    }
}

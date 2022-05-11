using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    [SerializeField] private Text _recordText;
    void Update()
    {
        _recordText.text = System.Convert.ToInt32(Ship.Instance.transform.position.z / 10).ToString();   
    }
}

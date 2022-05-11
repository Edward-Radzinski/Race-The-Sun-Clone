using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesMoving : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cubes = new List<GameObject>();
    [SerializeField] private float _speed;

    private void Update()
    {
        if(transform.position.z - Ship.Instance.transform.position.z < 250)
            CubesMovement();
        else
        {
            foreach (var item in _cubes)
                item.transform.position = new Vector3(item.transform.position.x, 78, item.transform.position.z);
        }
    }

    private void CubesMovement()
    {
        foreach (var item in _cubes)
            item.transform.position = Vector3.Lerp(item.transform.position, new Vector3(item.transform.position.x, 28, item.transform.position.z), _speed * Time.deltaTime);
    }
}

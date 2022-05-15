using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesMoving : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cubes = new List<GameObject>();
    
    [SerializeField] private float _speed;
    [SerializeField] private float _beginPositionY = 78;
    [SerializeField] private float _endPositionY = 28;
    private float _distantce = 250;
    

    private void Update()
    {
        if(transform.position.z - Ship.Instance.transform.position.z < _distantce) 
            CubesMovement();
        else
        {
            foreach (var item in _cubes)
                item.transform.position = new Vector3(item.transform.position.x, _beginPositionY, item.transform.position.z);
        }
    }

    private void CubesMovement()
    {
        foreach (var item in _cubes)
            item.transform.position = Vector3.Lerp(item.transform.position, new Vector3(item.transform.position.x, _endPositionY, item.transform.position.z), _speed * Time.deltaTime);
    }
}

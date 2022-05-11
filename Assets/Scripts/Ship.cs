using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public static Ship Instance;

    private Rigidbody _rb;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private bool _cameraRotation;
    [SerializeField] private float _rotationSpeed;
   
    private Vector3 _currentRotation;
    public float hMove = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _currentRotation = transform.eulerAngles;
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            //Destroy(gameObject);
            SceneManager.LoadScene("GameScene");
        }
    }

    private void Movement()
    {
        _currentRotation.z = hMove != 0 ? Mathf.Lerp(_currentRotation.z, -hMove * 25, _rotationSpeed * Time.fixedDeltaTime) : Mathf.Lerp(_currentRotation.z, 0, (_rotationSpeed * Time.fixedDeltaTime) / 2);
        transform.eulerAngles = _currentRotation;
        _rb.velocity = new Vector3(hMove * _turnSpeed, 0, _speed);
    }
}

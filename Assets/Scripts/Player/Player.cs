using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _takeDistance;
    [SerializeField] private float _holdDistance;
    [SerializeField] private float _throwForce;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Transform _camera;

    private Rigidbody _rigidbody;
    private GameObject _currentObject;
    private bool _picked = false;

    public UnityAction EndBlockPicked;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_picked == true)
            {
                Throw();
            }
            else
            {
                TryPickUp();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Throw(true);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, _speed * Time.deltaTime * -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space) && _groundChecker.IsGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void TryPickUp()
    {
        if (Physics.Raycast(_camera.position, _camera.forward, out var hitInfo, _takeDistance))
        {
            if (hitInfo.collider.gameObject.GetComponent<EndBlock>())
            {
                EndBlockPicked?.Invoke();
            }
            else if (hitInfo.collider.gameObject.GetComponent<PurpleCube>())
            {
                _currentObject = hitInfo.collider.gameObject;

                _currentObject.GetComponent<Collider>().enabled = false;
                _currentObject.transform.position = default;
                _currentObject.transform.SetParent(_camera, worldPositionStays: false);
                _currentObject.transform.localPosition = new Vector3(0, 0, _holdDistance);

                _currentObject.GetComponent<Rigidbody>().isKinematic = true;
                _picked = true;
            }
        }
    }

    private void Throw(bool drop = false)
    {
        _currentObject.transform.parent = null;
        _currentObject.GetComponent<Collider>().enabled = true;

        var rigidbody = _currentObject.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;

        if (drop == true)
            rigidbody.AddForce(_camera.forward * _throwForce, ForceMode.Impulse);
        _picked = false;
    }
}
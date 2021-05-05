using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 100f;

    private Transform _player;
    private float _mouseX;
    private float _mouseY;
    private float _rotationX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _player = GetComponentInParent<Player>().transform;
    }

    private void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _rotationX -= _mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        _player.Rotate(Vector3.up * _mouseX);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Rigidbody2D _pivot;
    [SerializeField] private float _detachTime;
    [SerializeField] private float _respawnDelay;


    private Rigidbody2D _currentBallRigidbody;
    private SpringJoint2D _currentBallSprintJoint;

    private Camera _mainCamera;
    private Boolean _isDragging;

    // Start is called before the first frame update
    void Start()
    {
        //_mainCamera = Camera.main;
        _mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Drow the ball 
        if (_currentBallRigidbody == null) return;

        //Release The Ball
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (_isDragging)
            {
                LaunchBall();
            }
            _isDragging = false;
            return;
        }

        //Hold The Ball
        _isDragging = true;
        _currentBallRigidbody.isKinematic = true;
        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(touchPosition);
        _currentBallRigidbody.position = worldPosition;

    }

    private void LaunchBall()
    {
        _currentBallRigidbody.isKinematic = false;
        _currentBallRigidbody = null;

        // Invoke("DetachBall", _detachTime);
        Invoke(nameof(DetachBall), _detachTime);
    }

    private void DetachBall()
    {
        _currentBallSprintJoint.enabled = false;
        _currentBallSprintJoint = null;
    }
}

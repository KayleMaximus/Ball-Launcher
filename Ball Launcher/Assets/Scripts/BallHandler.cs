using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _currentBallRigidbody;

    private Camera _mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //_mainCamera = Camera.main;
        _mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Touchscreen.current.primaryTouch.press.isPressed){
            _currentBallRigidbody.isKinematic = false;
            return;
        }
        _currentBallRigidbody.isKinematic = true;
        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(touchPosition);
        _currentBallRigidbody.position = worldPosition;
        
    }
}

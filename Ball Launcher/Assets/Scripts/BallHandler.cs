using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
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
            return;
        }
        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

        Debug.Log(worldPosition);
    }
}

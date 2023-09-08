using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float upY;
    [SerializeField] private float downY;
    [SerializeField] private float leftX;
    [SerializeField] private float rightX;

    private Transform _transformY;
    private Transform _transformX;
    private Vector2 _currentPosY;
    private Vector2 _currentPosX;

    // Use this for initialization
    void Start()
    {
        _transformY = gameObject.GetComponent<Transform>();
        _currentPosY = _transformY.position;

        _transformX = gameObject.GetComponent<Transform>();
        _currentPosX = _transformX.position;
    }

    // Update is called once per frame
    void Update()
    {
        _currentPosY = _transformY.position;
        _currentPosX = _transformX.position;

        float userInputV = Input.GetAxis("Vertical");
        float userInputH = Input.GetAxis("Horizontal");

        if (userInputV < 0)
            _currentPosY -= new Vector2(0, speed);

        if (userInputV > 0)
            _currentPosY += new Vector2(0, speed);

        if (userInputH < 0)
            _currentPosX -= new Vector2(speed, 0);

        if (userInputH > 0)
            _currentPosX += new Vector2(speed, 0);

        CheckBoundary();

        _transformY.position = _currentPosY;
        _transformX.position = _currentPosX;
    }

    private void CheckBoundary()
    {
        if (_currentPosY.y < upY)
            _currentPosY.y = upY;

        if (_currentPosY.y > downY)
            _currentPosY.y = downY;

        if (_currentPosX.x < leftX)
            _currentPosX.x = leftX;

        if (_currentPosX.x > rightX)
            _currentPosX.x = rightX;
    }

}

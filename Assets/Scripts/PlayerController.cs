using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] float _speed = 4f;
    [SerializeField] float _inputDeadZone = .5f;

    [Header("DirectionSprites")]
    [SerializeField] GameObject[] _lookDirections;

    Vector2 _inputs;

    Rigidbody2D _rb;
    Animator _animator;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _inputs.x = Input.GetAxisRaw("Horizontal");
        _inputs.y = Input.GetAxisRaw("Vertical");        
        _animator.SetFloat("Horizontal", _inputs.x);
        _animator.SetFloat("Vertical", _inputs.y);

        //_animator.SetFloat("Speed", _inputs.sqrMagnitude);
        _animator.SetFloat("Speed", Math.Clamp(_inputs.sqrMagnitude,0f,1f));
        ShowSpriteDirection();

    }

    private void ShowSpriteDirection()
    {
        if (_inputs.x > _inputDeadZone)
        {
            _lookDirections[3].SetActive(true);
            _lookDirections[0].SetActive(false);
            _lookDirections[1].SetActive(false);
            _lookDirections[2].SetActive(false);
        }
        else if (_inputs.x < -_inputDeadZone)
        {
            _lookDirections[2].SetActive(true);
            _lookDirections[0].SetActive(false);
            _lookDirections[1].SetActive(false);
            _lookDirections[3].SetActive(false);
        }
        else if (_inputs.y > _inputDeadZone)
        {
            _lookDirections[0].SetActive(true);
            _lookDirections[1].SetActive(false);
            _lookDirections[2].SetActive(false);
            _lookDirections[3].SetActive(false); 
        }
        else
        {
            _lookDirections[1].SetActive(true);
            _lookDirections[2].SetActive(false);
            _lookDirections[3].SetActive(false);
            _lookDirections[0].SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _inputs.normalized * _speed * Time.fixedDeltaTime);
    }
}

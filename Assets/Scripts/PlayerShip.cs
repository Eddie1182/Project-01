using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 0.25f;
    [SerializeField] float _turnSpeed = 1f;

    Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveShip();

        turnShip();
    }

    private void moveShip()
    {
        //detect input to caluculate
        float moveAmountThisFrame = Input.GetAxis("Vertical") * _moveSpeed;
        //determine where to move
        Vector3 moveDirection = transform.forward * moveAmountThisFrame;
        //move the rigidbody
        _rb.AddForce(moveDirection);
    }

    private void turnShip()
    {
        float turnAmountThisFrame = Input.GetAxis("Horizontal") * _turnSpeed;

        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);

        _rb.MoveRotation(_rb.rotation * turnOffset); ;
    }

 }

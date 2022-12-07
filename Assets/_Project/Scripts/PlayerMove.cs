using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController _characterController;

    private Animator _animatorController;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;

    [SerializeField]
    private Joystick _rightJoystick;

    private bool _isOwner;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animatorController = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_isOwner) return;

        groundedPlayer = _characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(_rightJoystick.xAxis.value, 0, _rightJoystick.yAxis.value);
        _characterController.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        _animatorController.SetFloat("Movement", move.magnitude);
    }

    public void UpdateOwner(bool isOwner)
    {
        _isOwner = isOwner;
    }
}

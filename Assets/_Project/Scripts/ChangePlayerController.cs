using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerController : MonoBehaviour
{
    [SerializeField]
    private ChangePlayerView _changePlayerView;

    [SerializeField]
    private PlayerMove _robotPlayerMove;

    [SerializeField]
    private PlayerMove _humanPlayerMove;

    [SerializeField]
    private CinemachineVirtualCamera _humanVirtualCamera;

    [SerializeField]
    private CinemachineVirtualCamera _robotVirtualCamera;

    private void Start()
    {
        OnPlayerChangeButtonClicked(PlayerKind.Human);
    }

    private void OnEnable()
    {
        _changePlayerView.PlayerChangeButtonClicked += OnPlayerChangeButtonClicked;
    }

    private void OnDisable()
    {
        _changePlayerView.PlayerChangeButtonClicked -= OnPlayerChangeButtonClicked;
    }

    private void OnPlayerChangeButtonClicked(PlayerKind playerKind)
    {
        if (playerKind == PlayerKind.Robot)
        {
            _robotPlayerMove.UpdateOwner(true);
            _humanPlayerMove.UpdateOwner(false);

            _robotVirtualCamera.Priority = 1;
            _humanVirtualCamera.Priority = 0;
        }
        
        if (playerKind == PlayerKind.Human)
        {
            _robotPlayerMove.UpdateOwner(false);
            _humanPlayerMove.UpdateOwner(true);

            _robotVirtualCamera.Priority = 0;
            _humanVirtualCamera.Priority = 1;
        }
    }
}

public enum PlayerKind
{
    Robot,
    Human
}

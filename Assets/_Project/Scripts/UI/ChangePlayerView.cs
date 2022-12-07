using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerView : MonoBehaviour
{
    [SerializeField]
    private Button _changePlayerToHumanButton;

    [SerializeField]
    private Button _changePlayerToRobotButton;

    public Action<PlayerKind> PlayerChangeButtonClicked;

    private void OnEnable()
    {
        _changePlayerToHumanButton.onClick.AddListener(OnChangePlayerToHumanButtonClicked);
        _changePlayerToRobotButton.onClick.AddListener(OnChangePlayerToRobotButtonClicked);
    }

    private void OnDisable()
    {
        _changePlayerToHumanButton.onClick.RemoveListener(OnChangePlayerToHumanButtonClicked);
        _changePlayerToRobotButton.onClick.RemoveListener(OnChangePlayerToRobotButtonClicked);
    }

    private void OnChangePlayerToRobotButtonClicked()
    {
        PlayerChangeButtonClicked.Invoke(PlayerKind.Robot);
    }

    private void OnChangePlayerToHumanButtonClicked()
    {
        PlayerChangeButtonClicked.Invoke(PlayerKind.Human);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private Transform[] _destinationPoints;

    private Animator _animatorController;

    private int _currentDestionationPositionIndex;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animatorController = GetComponent<Animator>();

        _animatorController.SetBool("IsWalking", true);

        _navMeshAgent.SetDestination(_destinationPoints[_currentDestionationPositionIndex].position);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _destinationPoints[_currentDestionationPositionIndex].position) < 0.2)
        {
            if (_currentDestionationPositionIndex == _destinationPoints.Length - 1)
            {
                _animatorController.SetBool("IsWalking",false);

                return;
            }

            _animatorController.SetBool("IsWalking", true);

            _currentDestionationPositionIndex++;

            _navMeshAgent.SetDestination(_destinationPoints[_currentDestionationPositionIndex].position);
        }
    }
}

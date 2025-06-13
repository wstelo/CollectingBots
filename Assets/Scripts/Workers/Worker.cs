using System;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(WorkerAnimatorController), typeof(WorkerColllisionDetector))]
[RequireComponent(typeof(WorkerBag))]

public class Worker : MonoBehaviour
{
    private WorkerAnimatorController _animatorController;
    private WorkerColllisionDetector _colllisionDetector;
    private StateMachine _stateMachine;
    private WorkerBag _workerBags;
    private Mover _mover;
    private Vector3 _currentCampPosition;
    private float _workerDamage = 5f;

    public event Action <Worker> FinishedWork;
    public event Action AssignedNewTarget;

    public EnvironmentItem CurrentResourse { get; private set; } = null;
    public Vector3 CurrentCampPosition => _currentCampPosition;

    private void Awake()
    {
        _animatorController = GetComponent<WorkerAnimatorController>();
        _colllisionDetector = GetComponent<WorkerColllisionDetector>();
        _workerBags = GetComponent<WorkerBag>();
        _mover = GetComponent<Mover>();
    }

    private void Start()
    {
        _stateMachine = new StateMachine();
        _stateMachine.AddState(new WorkerMiningState(_stateMachine, _animatorController, _workerDamage, _workerBags, this));
        _stateMachine.AddState(new WorkerWalkState(_stateMachine, _animatorController, _mover, _colllisionDetector, this));
        _stateMachine.AddState(new WorkerReturnToBaseState(_stateMachine, _animatorController, _mover, this));
        _stateMachine.AddState(new WorkerIdleState(_stateMachine, _animatorController, this));
        _stateMachine.SetState<WorkerIdleState>();
    }

    private void FixedUpdate()
    {
        _stateMachine?.FixedUpdate();
    }

    public void FinishWork()
    {
        FinishedWork?.Invoke(this);
    }

    public void SetCurrentCampPosition(Vector3 campPosition)
    {
        _currentCampPosition = campPosition;
    }

    public void SetCurrentResourse(EnvironmentItem item)
    {
        CurrentResourse = item;
        AssignedNewTarget?.Invoke();
    }

    public void ClearCurrentResourse()
    {
        CurrentResourse = null;
    }
}

using System;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(WorkerAnimatorController), typeof(WorkerColllisionDetector))]
[RequireComponent(typeof(WorkerBag))]

public class Worker : MonoBehaviour
{
    private WorkerAnimatorController _animatorController;
    private WorkerColllisionDetector _colllisionDetector;
    private Vector3 _currentCampPosition;
    private StateMachine _stateMachine;
    private Transform _currentTarget;
    private float _workerDamage = 5f;
    private WorkerBag _workerBags;
    private Mover _mover;

    public event Action EmployedResourseDetected;
    public event Action <Worker> FinishedWork;

    public EnvironmentItem CurrentResourse { get; private set; } = null;
    public Vector3 CurrentCampPosition => _currentCampPosition;
    public Transform CurrentTarget => _currentTarget;

    private void Awake()
    {
        _workerBags = GetComponent<WorkerBag>();
        _mover = GetComponent<Mover>();
        _animatorController = GetComponent<WorkerAnimatorController>();
        _colllisionDetector = GetComponent<WorkerColllisionDetector>();
    }

    private void OnEnable()
    {
        _colllisionDetector.ResourseDetected += SetCurrentResourse;
    }

    private void OnDisable()
    {
        _colllisionDetector.ResourseDetected -= SetCurrentResourse;
    }

    private void Start()
    {
        _stateMachine = new StateMachine();
        _stateMachine.AddState(new WorkerIdleState(_stateMachine, _animatorController, this));
        _stateMachine.AddState(new WorkerWalkState(_stateMachine, _animatorController, _mover, _colllisionDetector, this));
        _stateMachine.AddState(new WorkerMiningState(_stateMachine, _animatorController, _workerDamage, _workerBags, this));
        _stateMachine.AddState(new WorkerReturnToBaseState(_stateMachine, _animatorController, _mover, this));
        _stateMachine.SetState<WorkerIdleState>();
    }

    private void Update()
    {
        _stateMachine?.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine?.FixedUpdate();
    }

    public void FinishWork()
    {
        FinishedWork?.Invoke(this);
    }

    public void SetNewTarget(Transform item)
    {
        _currentTarget = item;
        EmployedResourseDetected?.Invoke();
    }

    public void SetCurrentCampPosition(Vector3 campPosition)
    {
        _currentCampPosition = campPosition;
    }

    private void SetCurrentResourse(EnvironmentItem item)
    {
        CurrentResourse = item;
    }
}

using UnityEngine;

public class WorkerWalkState : State
{
    private WorkerColllisionDetector _collisionDetector;
    private WorkerAnimatorController _controller;
    private Worker _worker;
    private Mover _mover;

    public WorkerWalkState(StateMachine stateMachine, WorkerAnimatorController animator, Mover mover, WorkerColllisionDetector collisionDetector, Worker worker) : base(stateMachine)
    {
        _collisionDetector = collisionDetector;
        _controller = animator;
        _worker  = worker;
        _mover = mover;
    }

    public override void Enter()
    {
        _controller.StartWalkAnimation();
        SetDesiredPosition(_worker.CurrentTarget);
        _collisionDetector.ResourseDetected += ChangeStateToMining;
    }

    public override void Exit()
    {
        _controller.StopWalkAnimation();

        _collisionDetector.ResourseDetected -= ChangeStateToMining;
    }

    private void SetDesiredPosition(Transform target)
    {
        _mover.MoveToPoint(target.transform.position);
    }

    private void ChangeStateToMining(EnvironmentItem item)
    {
        if(item.transform.position == _worker.CurrentTarget.position)
        {
            _mover.StopMovement();
            StateMachine.SetState<WorkerMiningState>();
        }
    }
}

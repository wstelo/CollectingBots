public class WorkerIdleState : State
{
    private WorkerAnimatorController _controller;
    private Worker _worker;

    public WorkerIdleState(StateMachine stateMachine, WorkerAnimatorController animator, Worker worker) : base(stateMachine)
    {
        _controller = animator;
        _worker = worker;
    }

    public override void Enter()
    {
        _controller.StartIdleAnimation();
        _worker.EmployedResourseDetected += WalkToPoint;
    }

    public override void Exit()
    {
        _controller.StopIdleAnimation();
        _worker.EmployedResourseDetected -= WalkToPoint;
    }

    private void WalkToPoint()
    {
        StateMachine.SetState<WorkerWalkState>();
    }
}

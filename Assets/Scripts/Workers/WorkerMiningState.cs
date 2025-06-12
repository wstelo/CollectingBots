using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerMiningState : State
{
    private WorkerAnimatorController _controller;
    private WorkerBag _workerBags;
    private Worker _worker;
    private float _currentMiningTime = 0f;
    private float _delayToMining = 0.9f;
    private float _minTime;
    private float _damage;

    public WorkerMiningState(StateMachine stateMachine, WorkerAnimatorController animator, float damage, WorkerBag workerBags, Worker worker) : base(stateMachine)
    {
        _controller = animator;
        _damage = damage;
        _worker = worker;
        _workerBags = workerBags;
    }

    public override void Enter()
    {
        _controller.StartMiningAnimation();
        _worker.CurrentResourse.Extracted += ChangeToMovementState;
    }

    public override void Update()
    {
        if(_worker.CurrentResourse != null)
        {
            _currentMiningTime += Time.deltaTime;

            if (_currentMiningTime > _delayToMining)
            {
                _worker.CurrentResourse.Extract(_damage);

                _currentMiningTime = _minTime;
            }
        }
    }

    public override void Exit()
    {
        _controller.StopMiningAnimation();
    }

    private void ChangeToMovementState(EnvironmentItem item)
    {
        _workerBags.PlaceProduct(item);
        StateMachine.SetState<WorkerReturnToBaseState>();
    }
}

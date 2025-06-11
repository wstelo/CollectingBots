using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorkerHandler))]

public class Camp : MonoBehaviour
{

    [SerializeField] private ResourseHandler _resourseDetector;
    [SerializeField] private int _timeToRefreshResourse = 1;
    [SerializeField] private int _startWorkerCount = 3;

    private List<Worker> _unemployedWorkers = new List<Worker>();
    private List<Worker> _employedWorkers = new List<Worker>();
    private WorkerHandler _workerHandler;

    private void Awake()
    {
        _workerHandler = GetComponent<WorkerHandler>();
    }

    private void Start()
    {
        StartCoroutine(SendWorkerToResourse());
        _unemployedWorkers = _workerHandler.GetWorkers(_startWorkerCount);
    }

    private IEnumerator SendWorkerToResourse()
    {
        var wait = new WaitForSeconds(_timeToRefreshResourse);

        while (enabled)
        {
            EnvironmentItem nearestItem = _resourseDetector.GetRandomNearestItem();

            if (nearestItem != null && _unemployedWorkers.Count > 0)
            {
                Worker currentWorker = _unemployedWorkers[UnityEngine.Random.Range(0, _unemployedWorkers.Count)];
                _unemployedWorkers.Remove(currentWorker);
                _employedWorkers.Add(currentWorker);
                currentWorker.SetNewTarget(nearestItem.transform);
            }

            yield return wait;
        }
    }
}

using System;
using UnityEngine;

[RequireComponent(typeof(EnvironmentItemHealth))]

public abstract class EnvironmentItem : MonoBehaviour
{
    private EnvironmentItemHealth _health;

    public event Action<EnvironmentItem> Extracted;
    public event Action<EnvironmentItem> Collected;

    private void Awake()
    {
        _health = GetComponent<EnvironmentItemHealth>();
    }

    private void OnEnable()
    {
        _health.Refresh();
        _health.Ended += ExtractedObject;
    }

    private void OnDisable()
    {   
        _health.Ended -= ExtractedObject;
    }

    public void Extract(float damage)
    {
        _health.TakeDamage(damage);
    }

    private void ExtractedObject()
    {
        Extracted?.Invoke(this);
    }

    public void CollectedObject()
    {
        Collected?.Invoke(this);
    }
}

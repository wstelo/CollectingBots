using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private const string ScrollWheel = "Mouse ScrollWheel";

    public event Action <float> OnValueChanged;

    public float HorizontalValue {  get; private set; }
    public float VerticalValue { get; private set; }
    public float ScrollWheelValue { get; private set; }

    private void Update()
    {
        HorizontalValue = Input.GetAxis(HorizontalAxis);
        VerticalValue = Input.GetAxis(VerticalAxis);

        if(Input.GetAxis(ScrollWheel) != 0)
        {
            ScrollWheelValue = Input.GetAxis(ScrollWheel);
            OnValueChanged?.Invoke(ScrollWheelValue);
        }
    }
}

using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private float _smoothSpeed = 0.1f;

    private Vector3 desiredPosition;

    private void FixedUpdate()
    {
        if(_inputHandler.HorizontalValue != 0 || _inputHandler.VerticalValue != 0)
        {
            desiredPosition = transform.position + new Vector3(_inputHandler.HorizontalValue, 0, _inputHandler.VerticalValue);

            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.fixedDeltaTime / _smoothSpeed);
        }
    }
}

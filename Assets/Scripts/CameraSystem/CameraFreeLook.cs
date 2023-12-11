using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeLook : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerInputs inputs;
    [Header("Properties")]
    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private Vector2 minMaxXAngle;
    [SerializeField] private float smoothing;
    [SerializeField] private bool invertX;
    [SerializeField] private bool invertY;

    private Vector2 _targetAxis;
    private Vector2 _lookAxis;
    private Vector2 _lookVelocity;

    private void Update()
    {
        float smoothTime = smoothing;

        if (inputs.IsRMB)
        {
            _targetAxis = new Vector2(inputs.MouseX, inputs.MouseY);
            smoothTime /= 2;
        }
        else
        {
            _targetAxis = Vector2.zero;
        }

        _lookAxis = Vector2.SmoothDamp(_lookAxis, _targetAxis, ref _lookVelocity, smoothTime);

        float deltaTime = Time.deltaTime;
        Vector3 eulerAngles = transform.localEulerAngles;

        if (eulerAngles.x > 180) eulerAngles.x -= 360;

        eulerAngles.x += _lookAxis.y * sensitivity.y * (invertY ? -1 : 1) * deltaTime;
        eulerAngles.y += _lookAxis.x * sensitivity.x * (invertX ? -1 : 1) * deltaTime;

        eulerAngles.x = Mathf.Clamp(eulerAngles.x, minMaxXAngle.x, minMaxXAngle.y);

        transform.localEulerAngles = eulerAngles;
    }

}

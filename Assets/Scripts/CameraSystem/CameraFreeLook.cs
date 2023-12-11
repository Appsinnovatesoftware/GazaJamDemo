using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraFreeLook : MonoBehaviour
{
    private static CameraFreeLook _currentActiveCamera;

    public bool IsCurrentActive => _currentActiveCamera == this;

    [Header("Data")]
    [SerializeField] private PlayerInputs inputs;
    [Header("Properties")]
    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private Vector2 minMaxXAngle;
    [SerializeField] private float smoothing;
    [SerializeField] private bool invertX;
    [SerializeField] private bool invertY;


    private CinemachineVirtualCamera _virtualCamera;
    private bool _canDrag = false;
    private Vector2 _targetAxis;
    private Vector2 _lookAxis;
    private Vector2 _lookVelocity;

    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();

    }

    private void Update()
    {
        if (inputs.IsLMBDown && !Clickable.CurrentHighlighted)
        {
            _canDrag = true;
        }

        float smoothTime = smoothing;

        if (inputs.IsLMB && _canDrag)
        {
            _targetAxis = new Vector2(inputs.MouseX, inputs.MouseY);
            smoothTime /= 2;
        }
        else
        {
            _canDrag = false;
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


    public void Enable()
    {
        if (_currentActiveCamera)
        {
            _currentActiveCamera.Disable();
        }
        _virtualCamera.enabled = true;
        _currentActiveCamera = this;
    }

    public void Disable()
    {
        _virtualCamera.enabled = false;
    }

}

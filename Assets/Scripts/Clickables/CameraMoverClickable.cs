using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoverClickable : Clickable
{
    [SerializeField] private bool activeOnStart;
    [Space]

    [SerializeField] private CameraFreeLook targetCamera;
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject highlight;

    private bool? _lastCameraActive = null;


    private void OnValidate()
    {
#if UNITY_EDITOR
        if (activeOnStart)
        {
            CameraMoverClickable[] cameras = Object.FindObjectsOfType<CameraMoverClickable>();
            for (int i = 0; i < cameras.Length; i++)
            {
                UnityEditor.EditorUtility.SetDirty(cameras[i]);
                UnityEditor.Undo.RecordObject(cameras[i], "Change active camera");
                cameras[i].activeOnStart = cameras[i] == this;
            }
        }
#endif
    }


    protected override void Awake()
    {
        base.Awake();

        highlight.SetActive(false);
    }

    private void Start()
    {
        if (activeOnStart)
        {
            targetCamera.Enable();
        }
        else
        {
            targetCamera.Disable();
        }
    }

    private void Update()
    {
        if (_lastCameraActive == null || _lastCameraActive.Value != targetCamera.IsCurrentActive)
        {
            indicator.SetActive(!targetCamera.IsCurrentActive);

            SetColliderActive(!targetCamera.IsCurrentActive);

            _lastCameraActive = targetCamera.IsCurrentActive;
        }
    }

    protected override void OnClick()
    {
        targetCamera.Enable();
    }

    protected override void OnHighlight()
    {
        highlight.gameObject.SetActive(true);
    }

    protected override void OnUnhighlight()
    {
        highlight.gameObject.SetActive(false);
    }
}

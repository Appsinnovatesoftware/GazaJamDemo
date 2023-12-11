using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputsController : MonoBehaviour
{

    [SerializeField] private PlayerInputs inputs;

    private void Update()
    {
        inputs.MouseScreenPosition = Input.mousePosition;
        inputs.MouseX = Input.GetAxisRaw("Mouse X");
        inputs.MouseY = Input.GetAxisRaw("Mouse Y");

        inputs.IsLMB = Input.GetMouseButton(0);
        inputs.IsRMB = Input.GetMouseButton(1);
        inputs.IsLMBDown = Input.GetMouseButtonDown(0);
        inputs.IsRMBDown = Input.GetMouseButtonDown(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Place a PlayerInputsController prefab in the scene to update these data

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerInputs")]
public class PlayerInputs : ScriptableObject
{
    public Vector2 MouseScreenPosition;

    public float MouseX;
    public float MouseY;

    public bool IsLMB;
    public bool IsRMB;

    public bool IsLMBDown;
    public bool IsRMBDown;
}

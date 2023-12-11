using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateClickable : Clickable
{
    [SerializeField] private Animator animator;
    [SerializeField] private string trigger;

    private bool _isClicked = false;

    protected override void OnClick()
    {
        if (_isClicked) return;

        _isClicked = true;

        animator.SetTrigger(trigger);
    }

    protected override void OnHighlight()
    {
        if (_isClicked) return;

        transform.LeanScale(Vector3.one * 1.05f, 0.15f)
            .setEaseOutBack();

    }

    protected override void OnUnhighlight()
    {
        transform.LeanScale(Vector3.one, 0.35f)
            .setEaseOutBack();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadClickable : Clickable
{
    private bool _isClicked = false;

    protected override void OnClick()
    {
        if (_isClicked) return;

        _isClicked = true;

        Camera camera = Camera.main;
        Vector3 startPosition = transform.position;

        LeanTween.value(0f, 1f, 0.75f)
            .setOnUpdate((float t) =>
            {
                Vector3 p1 = Vector3.Lerp(startPosition, startPosition + Vector3.up, t);
                Vector3 p2 = Vector3.Lerp(startPosition + Vector3.up, camera.transform.position + Vector3.down * 0.5f, t);

                transform.position = Vector3.Lerp(p1, p2, t);
            });


        Stats.BreadCount++;

        Debug.Log($"[BreadClickable] Bread collected: {Stats.BreadCount}");
    }

    protected override void OnHighlight()
    {
        if (_isClicked) return;

        transform.LeanScale(Vector3.one * 1.05f, 0.15f)
            .setEaseOutBack();

    }

    protected override void OnUnhighlight()
    {
        if (_isClicked) return;

        transform.LeanScale(Vector3.one, 0.35f)
            .setEaseOutBack();
    }
}

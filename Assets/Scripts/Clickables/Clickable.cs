using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public abstract class Clickable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static Clickable CurrentHighlighted { get; private set; }

    private Collider _collider;

    protected abstract void OnClick();
    protected abstract void OnHighlight();
    protected abstract void OnUnhighlight();

    protected virtual void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        CurrentHighlighted = this;
        OnHighlight();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (CurrentHighlighted == this)
        {
            CurrentHighlighted = null;
        }
        OnUnhighlight();
    }

    protected void SetColliderActive(bool isActive)
    {
        _collider.enabled = isActive;
    }
}

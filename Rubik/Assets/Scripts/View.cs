using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class View : MonoBehaviour , IPointerUpHandler, IPointerDownHandler
{
    private Vector3 start;
    public ViewEvent onViewChange;

    public void OnPointerDown(PointerEventData eventData)
    {
        start = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        MoveDirection direction = MoveDirection.None;

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        var dif = start - curScreenPoint;
        if (Mathf.Abs(dif.x) > Mathf.Abs(dif.y))
            direction = dif.x > 0 ? MoveDirection.Left : MoveDirection.Right;
        else
            direction = dif.y > 0 ? MoveDirection.Down : MoveDirection.Up;

        onViewChange.Invoke(direction);
    }

    [Serializable]
    public class ViewEvent : UnityEvent<MoveDirection>
    {
    }
}

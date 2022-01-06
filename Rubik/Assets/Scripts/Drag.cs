using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    private Vector3 start;
    public DragEvent faceMoved;

    private void OnMouseDown()
    {
        start = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }
    private void OnMouseUp()
    {
        //cara seleccionada del bloque
        Block.FaceType faceType =
            System.Math.Round(gameObject.transform.position.z, 1) == 1.5f ? Block.FaceType.Front :
            System.Math.Round(gameObject.transform.position.x, 1) == 1.5f ? Block.FaceType.Left :
            Block.FaceType.Top;

        MoveDirection direction = MoveDirection.None;

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        var dif = start - curScreenPoint;
        if (Mathf.Abs(dif.x) > Mathf.Abs(dif.y))
            direction = dif.x > 0 ? MoveDirection.Left : MoveDirection.Right;
        else
            direction = dif.y > 0 ? MoveDirection.Down : MoveDirection.Up;

        faceMoved.Invoke(faceType, direction);
    }
    [Serializable]
    public class DragEvent:UnityEvent<Block.FaceType, MoveDirection>
    {
    }
}

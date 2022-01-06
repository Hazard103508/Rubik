using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rubik : MonoBehaviour
{
    #region Objects
    [SerializeField] List<Block> blocks;
    #endregion

    #region Properties
    /// <summary>
    /// Estado actual del rubik
    /// </summary>
    private States State { get; set; }
    #endregion

    #region Unity Methods
    void Start()
    {
        State = States.Idle;
        blocks.ForEach(b => b.onBlockMove.AddListener(onBlockMoved));
    }
    #endregion

    #region Event Methods

    public void OnViewChanged(MoveDirection direction)
    {
        if (this.State != States.Idle)
            return;

        switch (direction)
        {
            case MoveDirection.Left:
                Rotate(Directions.Row_Left, Faces.Row_Top);
                Rotate(Directions.Row_Left, Faces.Row_Middle);
                Rotate(Directions.Row_Left, Faces.Row_Bottom);
                break;
            case MoveDirection.Right:
                Rotate(Directions.Row_Right, Faces.Row_Top);
                Rotate(Directions.Row_Right, Faces.Row_Middle);
                Rotate(Directions.Row_Right, Faces.Row_Bottom);
                break;
            case MoveDirection.Up:
                Rotate(Directions.Up, Faces.Column_Left);
                Rotate(Directions.Up, Faces.Column_Middle);
                Rotate(Directions.Up, Faces.Column_Right);
                break;
            case MoveDirection.Down:
                Rotate(Directions.Down, Faces.Column_Left);
                Rotate(Directions.Down, Faces.Column_Middle);
                Rotate(Directions.Down, Faces.Column_Right);
                break;
        }

    }
    private void onBlockMoved(Vector3 blockLocation, Block.FaceType faceType, MoveDirection moveDirection)
    {
        if (this.State != States.Idle)
            return;

        int x = (int)Math.Round(blockLocation.x, 0);
        int y = (int)Math.Round(blockLocation.y, 0);
        int z = (int)Math.Round(blockLocation.z, 0);

        Vector3[] row = y == -1 ? Faces.Row_Bottom : y == 0 ? Faces.Row_Middle : Faces.Row_Top;
        Vector3[] col = x == -1 ? Faces.Column_Left : x == 0 ? Faces.Column_Middle : Faces.Column_Right;
        Vector3[] face = z == -1 ? Faces.Face_Front : z == 0 ? Faces.Face_Middle : Faces.Face_Back;

        switch (faceType)
        {
            case Block.FaceType.Front:
                if (moveDirection == MoveDirection.Left)
                    Rotate(Directions.Row_Left, row);
                else if (moveDirection == MoveDirection.Right)
                    Rotate(Directions.Row_Right, row);
                else if (moveDirection == MoveDirection.Up)
                    Rotate(Directions.Up, col);
                else if (moveDirection == MoveDirection.Down)
                    Rotate(Directions.Down, col);
                break;
            case Block.FaceType.Left:
                if (moveDirection == MoveDirection.Left)
                    Rotate(Directions.Row_Left, row);
                else if (moveDirection == MoveDirection.Right)
                    Rotate(Directions.Row_Right, row);
                else if (moveDirection == MoveDirection.Up)
                    Rotate(Directions.Face_Right, face);
                else if (moveDirection == MoveDirection.Down)
                    Rotate(Directions.Face_Left, face);
                break;
            case Block.FaceType.Top:
                if (moveDirection == MoveDirection.Right)
                    Rotate(Directions.Face_Right, face);
                else if (moveDirection == MoveDirection.Left)
                    Rotate(Directions.Face_Left, face);
                else if (moveDirection == MoveDirection.Up)
                    Rotate(Directions.Up, col);
                else if (moveDirection == MoveDirection.Down)
                    Rotate(Directions.Down, col);
                break;
            default:
                break;
        }
    }
    #endregion

    #region Private Methods
    private Block[] Get_BlockRow(int x)
    {
        return blocks.Where(b => b.transform.position.ToInt().x == x).ToArray();
    }
    private Block[] Get_BlockColumn(int y)
    {
        return blocks.Where(b => b.transform.position.ToInt().y == y).ToArray();
    }
    private Block[] Get_BlockFace(int z)
    {
        return blocks.Where(b => b.transform.position.ToInt().z == z).ToArray();
    }
    private void Rotate(Directions direction, Vector3[] blocksLocation)
    {
        this.State = States.Moving;

        var lstBlocks = blocks.Where(b => blocksLocation.Contains(b.transform.position.ToInt())).ToList();

        Vector3 axis =
            direction == Directions.Up ? Vector3.left :
            direction == Directions.Down ? Vector3.right :
            direction == Directions.Row_Left ? Vector3.up :
            direction == Directions.Row_Right ? Vector3.down :
            direction == Directions.Face_Right ? Vector3.forward :
            direction == Directions.Face_Left ? Vector3.back :
            Vector3.zero;

        StartCoroutine(Rotate_Block(lstBlocks, 90, axis));
    }
    private IEnumerator Rotate_Block(List<Block> block, float angle, Vector3 axis)
    {
        float delay = 0.5f;
        float t = 0.0f;

        while (t < delay)
        {
            t += Time.deltaTime;
            foreach (Block b in block)
            {
                var rotationAngle = axis * Mathf.MoveTowardsAngle(0, angle, Time.deltaTime * 90 / delay);
                b.transform.parent.Rotate(rotationAngle, Space.World);
            }
            yield return null;
        }

        foreach (Block b in block)
        {
            b.transform.parent.rotation = Quaternion.Euler(Fix_Angle(b.transform.parent.rotation.eulerAngles));
            b.transform.position = b.transform.position.ToInt();
        }

        this.State = States.Idle;
        yield return null;
    }
    private Vector3 Fix_Angle(Vector3 angle)
    {
        return new Vector3(Fix_Angle(angle.x), Fix_Angle(angle.y), Fix_Angle(angle.z));
    }
    private float Fix_Angle(float angle)
    {
        int[] angles = new int[] { 0, 90, 180, 270, 0 };
        int index = (int)Math.Round(angle / 90f, 0);
        return angles[index];
    }
    #endregion
}

public enum Directions
{
    Up,
    Down,
    Row_Left,
    Row_Right,
    Face_Right,
    Face_Left
}
enum States
{
    Idle,
    Moving
}
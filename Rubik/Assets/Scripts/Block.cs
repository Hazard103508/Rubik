using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour
{
    #region Objects
    [SerializeField] private FaceMaterial materials;
    [SerializeField] private Faces faces;
    [SerializeField] private FaceColors colors;

    public BlockEvent onBlockMove = new BlockEvent();
    #endregion

    #region Unity Methods
    private void Start()
    {

    }
    private void OnValidate()
    {
        Set_Color(faces.Front, colors.Front);
        Set_Color(faces.Back, colors.Back);
        Set_Color(faces.Left, colors.Left);
        Set_Color(faces.Right, colors.Right);
        Set_Color(faces.Top, colors.Top);
        Set_Color(faces.Bottom, colors.Bottom);
    }
    private void OnMouseDrag()
    {
        //float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
    }
    #endregion

    #region Public Methods
    public void OnFaceDrag(FaceType faceType, MoveDirection moveDirection)
    {
        onBlockMove.Invoke(gameObject.transform.position, faceType, moveDirection);
    }
    #endregion

    #region private Methods
    /// <summary>
    /// Setea el color de la cara correspondiente
    /// </summary>
    /// <param name="render">cara a colorear</param>
    /// <param name="color">color a aplicar</param>
    private void Set_Color(MeshRenderer render, RubikColors color)
    {
        if (color == RubikColors.None)
            render.gameObject.SetActive(false);
        else
        {
            if (!render.gameObject.activeSelf)
                render.gameObject.SetActive(true);

            render.material =
                color == RubikColors.White ? materials.white :
                color == RubikColors.Blue ? materials.blue :
                color == RubikColors.Red ? materials.red :
                color == RubikColors.Green ? materials.green :
                color == RubikColors.Yellow ? materials.yellow :
                color == RubikColors.Orange ? materials.orange :
                null;
        }
    }
    #endregion


    public enum RubikColors
    {
        None,
        Blue,
        Red,
        Green,
        Orange,
        Yellow,
        White
    }
    public enum FaceType
    {
        Front,
        Left,
        Top
    }

    [Serializable]
    public class FaceMaterial
    {
        public Material red;
        public Material green;
        public Material blue;
        public Material yellow;
        public Material white;
        public Material orange;
    }
    [Serializable]
    public class FaceColors
    {
        public RubikColors Front;
        public RubikColors Back;
        public RubikColors Left;
        public RubikColors Right;
        public RubikColors Top;
        public RubikColors Bottom;
    }
    [Serializable]
    public class Faces
    {
        public MeshRenderer Front;
        public MeshRenderer Back;
        public MeshRenderer Left;
        public MeshRenderer Right;
        public MeshRenderer Top;
        public MeshRenderer Bottom;
    }
    public class BlockEvent : UnityEvent<Vector3, Block.FaceType, MoveDirection>
    {
    }
}

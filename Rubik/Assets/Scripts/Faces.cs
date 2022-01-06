using UnityEngine;

public static class Faces
{
    private static Vector3[] row_Middle = new Vector3[] {
                new Vector3(-1, 0, -1),
                new Vector3( 0, 0, -1),
                new Vector3( 1, 0, -1),
                new Vector3(-1, 0, 0),
                //new Vector3( 0, 0, 0),
                new Vector3( 1, 0, 0),
                new Vector3(-1, 0, 1),
                new Vector3( 0, 0, 1),
                new Vector3( 1, 0, 1)
            };

    private static Vector3[] row_Top = new Vector3[] {
                new Vector3(-1, 1, -1),
                new Vector3( 0, 1, -1),
                new Vector3( 1, 1, -1),
                new Vector3(-1, 1, 0),
                new Vector3( 0, 1, 0),
                new Vector3( 1, 1, 0),
                new Vector3(-1, 1, 1),
                new Vector3( 0, 1, 1),
                new Vector3( 1, 1, 1)
            };

    private static Vector3[] row_Bottom = new Vector3[] {
                new Vector3(-1, -1, -1),
                new Vector3( 0, -1, -1),
                new Vector3( 1, -1, -1),
                new Vector3(-1, -1, 0),
                new Vector3( 0, -1, 0),
                new Vector3( 1, -1, 0),
                new Vector3(-1, -1, 1),
                new Vector3( 0, -1, 1),
                new Vector3( 1, -1, 1)
            };

    private static Vector3[] column_left = new Vector3[] {
                new Vector3(-1,-1,1),
                new Vector3(-1,-1,0),
                new Vector3(-1,-1,-1),
                new Vector3(-1,0,1),
                new Vector3(-1,0,0),
                new Vector3(-1,0,-1),
                new Vector3(-1,1,1),
                new Vector3(-1,1,0),
                new Vector3(-1,1,-1)
            };

    private static Vector3[] column_middle = new Vector3[] {
                new Vector3(0,-1,1),
                new Vector3(0,-1,0),
                new Vector3(0,-1,-1),
                new Vector3(0,0,1),
                new Vector3(0,0,0),
                new Vector3(0,0,-1),
                new Vector3(0,1,1),
                new Vector3(0,1,0),
                new Vector3(0,1,-1)
            };

    private static Vector3[] column_right = new Vector3[] {
                new Vector3(1,-1,1),
                new Vector3(1,-1,0),
                new Vector3(1,-1,-1),
                new Vector3(1,0,1),
                new Vector3(1,0,0),
                new Vector3(1,0,-1),
                new Vector3(1,1,1),
                new Vector3(1,1,0),
                new Vector3(1,1,-1)
            };

    private static Vector3[] face_front = new Vector3[] {
                new Vector3(-1,1,-1),
                new Vector3(0, 1, -1),
                new Vector3(1,1,-1),
                new Vector3(-1,0,-1),
                new Vector3(0,0,-1),
                new Vector3(1,0,-1),
                new Vector3(-1,-1,-1),
                new Vector3(0,-1,-1),
                new Vector3(1,-1,-1),
            };

    private static Vector3[] face_middle = new Vector3[] {
                new Vector3(-1,1,0),
                new Vector3(0, 1,0),
                new Vector3(1,1,0),
                new Vector3(-1,0,0),
                new Vector3(0,0,0),
                new Vector3(1,0,0),
                new Vector3(-1,-1,0),
                new Vector3(0,-1,0),
                new Vector3(1,-1,0),
            };

    private static Vector3[] face_back = new Vector3[] {
                new Vector3(-1,1,1),
                new Vector3(0, 1,1),
                new Vector3(1,1,1),
                new Vector3(-1,0,1),
                new Vector3(0,0,1),
                new Vector3(1,0,1),
                new Vector3(-1,-1,1),
                new Vector3(0,-1,1),
                new Vector3(1,-1,1),
            };

    /// <summary>
    /// Coordenadas de fila central
    /// </summary>
    public static Vector3[] Row_Middle { get => row_Middle; }
    /// <summary>
    /// Coordenadas de fila superior
    /// </summary>
    public static Vector3[] Row_Top { get => row_Top; }
    /// <summary>
    /// Coordenadas de fila inferior
    /// </summary>
    public static Vector3[] Row_Bottom { get => row_Bottom; }

    /// <summary>
    /// Coordenadas de fila central
    /// </summary>
    public static Vector3[] Column_Left { get => column_left; }
    /// <summary>
    /// Coordenadas de fila central
    /// </summary>
    public static Vector3[] Column_Middle { get => column_middle; }
    /// <summary>
    /// Coordenadas de fila central
    /// </summary>
    public static Vector3[] Column_Right { get => column_right; }

    /// <summary>
    /// Coordenadas de cara frontal del cubo
    /// </summary>
    public static Vector3[] Face_Front { get => face_front; }
    /// <summary>
    /// Coordenadas de cara central del cubo
    /// </summary>
    public static Vector3[] Face_Middle { get => face_middle; }
    /// <summary>
    /// Coordenadas de cara trasera del cubo
    /// </summary>
    public static Vector3[] Face_Back { get => face_back; }

}

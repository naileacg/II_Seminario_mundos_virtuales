using UnityEngine;

public class MatrixDebugger : MonoBehaviour
{
    public Transform cube;
    public Camera mainCamera;
    public float rotationSpeed = 50f;
    public float moveSpeed = 2f;

    private bool isPerspective = true;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        cube.Translate(new Vector3(moveX, 0, moveZ), Space.World);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            PrintMatrixes();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            cube.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);
            PrintMatrixes();
        }

        if (Input.GetKey(KeyCode.E))
        {
            cube.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
            PrintMatrixes();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mainCamera.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);
            PrintMatrixes();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            mainCamera.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
            PrintMatrixes();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            isPerspective = !isPerspective;
            mainCamera.orthographic = !isPerspective;
            PrintMatrixes();
        }
    }

    void PrintMatrixes()
    {
        Debug.Log("Model Matrix (Cube):\n" + MatrixToString(cube.localToWorldMatrix));
        Debug.Log("View Matrix (Camera):\n" + MatrixToString(mainCamera.worldToCameraMatrix));
        Debug.Log("Projection Matrix (Camera):\n" + MatrixToString(mainCamera.projectionMatrix));
    }

    string MatrixToString(Matrix4x4 m)
    {
        return
            $"{m.m00:F2} {m.m01:F2} {m.m02:F2} {m.m03:F2}\n" +
            $"{m.m10:F2} {m.m11:F2} {m.m12:F2} {m.m13:F2}\n" +
            $"{m.m20:F2} {m.m21:F2} {m.m22:F2} {m.m23:F2}\n" +
            $"{m.m30:F2} {m.m31:F2} {m.m32:F2} {m.m33:F2}";
    }
}

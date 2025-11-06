using UnityEngine;

public class Debugger : MonoBehaviour
{
    public Cube redCube;
    public Cube greenCube;
    public Cube blueCube;
    
    private Camera cam;

    Vector3 localVertex = new Vector3(0.5f, 0.5f, 0.5f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
        PrintMatrixes(redCube.transform, redCube.name);
        PrintMatrixes(greenCube.transform, greenCube.name);
        PrintMatrixes(blueCube.transform, blueCube.name);
    }

    void PrintMatrixes(Transform obj, string cubeName) 
    {
        GameObject newObj = new GameObject();
        Transform newTransform = newObj.transform;
        CopyTransformValues(obj, newTransform);
        newTransform.position += localVertex;
        Matrix4x4 model = newTransform.localToWorldMatrix;
        Matrix4x4 view = cam.worldToCameraMatrix;
        Matrix4x4 projection = cam.projectionMatrix;

        Debug.Log($"model matrix ({cubeName}):\n{model}");
        Debug.Log($"view matrix (Cámara):\n{view}");
        Debug.Log($"projection matrix (Cámara):\n{projection}");
    }

    void CopyTransformValues(Transform source, Transform target)
    {
        target.position = source.position;
        target.rotation = source.rotation;
        target.localScale = source.localScale;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

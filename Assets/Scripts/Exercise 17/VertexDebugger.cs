using UnityEngine;

public class VertexDebugger : MonoBehaviour
{
    public Vector3 localVertex = new Vector3(0.5f, 0.5f, 0.5f);

    void Start()
    {
        // --- 1. Local space ---
        Vector3 localPos = localVertex;
        Debug.Log("Local Space: " + localPos);

        // --- 2. World space ---
        Vector3 worldPos = transform.TransformPoint(localPos);
        Debug.Log("World Space: " + worldPos);

        // --- 3. View / Camera space ---
        Camera cam = Camera.main;
        Vector3 viewPos = cam.worldToCameraMatrix.MultiplyPoint(worldPos);
        Debug.Log("Camera/View Space: " + viewPos);

        // --- 4. Clip space ---
        Vector4 clipPos = cam.projectionMatrix * new Vector4(viewPos.x, viewPos.y, viewPos.z, 1);
        Debug.Log("Clip Space: " + clipPos);

        // --- 5. NDC (Normalized Device Coordinates) ---
        Vector3 ndcPos = new Vector3(clipPos.x / clipPos.w, clipPos.y / clipPos.w, clipPos.z / clipPos.w);
        Debug.Log("NDC: " + ndcPos);

        // --- 6. Viewport coordinates (0-1) ---
        Vector3 viewportPos = new Vector3((ndcPos.x + 1) / 2f, (ndcPos.y + 1) / 2f, ndcPos.z);
        Debug.Log("Viewport: " + viewportPos);
    }
}

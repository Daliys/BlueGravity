using UnityEngine;

public class RenderCameraForUI : MonoBehaviour
{
    
    [SerializeField] private Transform followingTarget;
    [SerializeField] private Camera camera;
    private Vector3 _offset;
    
    private void Start()
    {
        _offset = transform.position;
    }

    private void EnableCamera()
    {
        camera.enabled = true;
        this.transform.position = followingTarget.position + _offset;
    }
    
    private void DisableCamera()
    {
        camera.enabled = false;
    }


    private void OnEnable()
    {
        Input.OnInventoryPressed += EnableCamera;
        Input.OnCloseButtonPressed += DisableCamera;
    }
    
    private void OnDisable()
    {
        Input.OnInventoryPressed -= EnableCamera;
        Input.OnCloseButtonPressed -= DisableCamera;
        DisableCamera();
    }
}

using UnityEngine;

/// <summary>
///  This class is used to render in texture character models on the screen (It is used to display the inventory).
/// </summary>
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
        PlayerInput.OnInventoryPressed += EnableCamera;
        PlayerInput.OnCloseButtonPressed += DisableCamera;
    }
    
    private void OnDisable()
    {
        PlayerInput.OnInventoryPressed -= EnableCamera;
        PlayerInput.OnCloseButtonPressed -= DisableCamera;
        DisableCamera();
    }
}

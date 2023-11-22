using UnityEngine;

/// <summary>
///  Following camera for the player.
/// </summary>
public class CameraController : MonoBehaviour
{
   [SerializeField] private Transform followingTarget;
   
    void LateUpdate()
    {
        transform.position = new Vector3(followingTarget.position.x, followingTarget.position.y, transform.position.z);
    }
    
}

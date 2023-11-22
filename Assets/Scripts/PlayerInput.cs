using System;
using UnityEngine;

/// <summary>
///  This class is responsible for handling input from the player but not player movement.
/// </summary>
public class PlayerInput : MonoBehaviour
{
    public static event Action OnInventoryPressed;
    public static event Action OnCloseButtonPressed;
    public static event Action OnInteractPressed;


    private bool _isInventoryOpen;

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (_isInventoryOpen)
            {
                OnCloseButtonPressed?.Invoke();
            }
            else
            {
                OnInventoryPressed?.Invoke();
            }

            _isInventoryOpen = !_isInventoryOpen;
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            OnCloseButtonPressed?.Invoke();
            _isInventoryOpen = false;
        }
        else if (Input.GetButtonDown("Interact"))
        {
            OnInteractPressed?.Invoke();

        }
    }
}

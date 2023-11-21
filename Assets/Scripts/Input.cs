using System;
using UnityEngine;

/// <summary>
///  This class is responsible for handling input from the player but not player movement.
/// </summary>
public class Input : MonoBehaviour
{
    public static event Action OnInventoryPressed;
    public static event Action OnCloseButtonPressed;

    private bool _isInventoryOpen;
    
    void Update()
    {
        if (UnityEngine.Input.GetButtonDown("Inventory"))
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
        
        if(UnityEngine.Input.GetButtonDown("Cancel"))
        {
            OnCloseButtonPressed?.Invoke();
            _isInventoryOpen = false;
        }
    }
}

using System;
using UI;
using UnityEngine;

/// <summary>
///  This class is responsible for handling input from the player but not player movement.
/// </summary>
public class PlayerInput : MonoBehaviour
{
    public static event Action OnInventoryPressed;
    public static event Action OnCloseButtonPressed;
    public static event Action OnInteractPressed;


    private bool _isAnyUIAttach;

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (_isAnyUIAttach)
            {
                OnCloseButtonPressed?.Invoke();
            }
            else
            {
                OnInventoryPressed?.Invoke();
            }
            
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            OnCloseButtonPressed?.Invoke();
        }
        else if (Input.GetButtonDown("Interact"))
        {
            if(_isAnyUIAttach) return;
            
            OnInteractPressed?.Invoke();

        }
    }

    private void OnEnable()
    {
        GameUI.OnGamePaused += SetIsAnyUIAttach;
    }

    private void SetIsAnyUIAttach(bool isPause)
    {
        // If the game is paused, then the player cannot interact with the UI.
        _isAnyUIAttach = isPause;
    }

    private void OnDisable()
    {
        GameUI.OnGamePaused -= SetIsAnyUIAttach;
    }

}

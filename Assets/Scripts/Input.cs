using System;
using UnityEngine;

public class Input : MonoBehaviour
{
    public static event Action OnInventoryPressed;
    public static event Action OnCloseButtonPressed;

    private bool _isInventoryOpen;
    
    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetButtonDown("Inventory")) // "Inventory" should match the name you set in the Input Manager
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
        }
    }
}

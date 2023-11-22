using System;

/// <summary>
///  Class that holds all the events that can be used by other classes.
/// </summary>
public abstract class ActionEvent
{
    public static event Action<string> OnHintTextChanged;
        
    public static void ChangeHintText(string newText)
    {
        OnHintTextChanged?.Invoke(newText);
    }

}
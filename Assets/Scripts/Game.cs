using System;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
///  Class for storing game data. But for now, it only stores the number of coins. 
/// </summary>
public class Game : MonoBehaviour
{
    public static event Action<int> OnCoinChanged;
    
    public static Game Instance { get; private set; }
    
    [SerializeField] private int coins;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // The object will not be destroyed when loading a new scene.
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        OnCoinChanged?.Invoke(coins);
    }

    public void AddCoin(int coin)
    {
        coins += coin;
        OnCoinChanged?.Invoke(coins);
    }
    
    public void RemoveCoin(int coin)
    {
        coins -= coin;
        OnCoinChanged?.Invoke(coins);
    }
    
    public bool HasEnoughCoin(int coin)
    {
        return coins >= coin;
    }

}
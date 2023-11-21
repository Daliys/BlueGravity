using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
    
    private static readonly int Speed = Animator.StringToHash("Speed");
    
    private Animator _animator;
    private bool _isAllowPlayerInput = true;
    private Vector3 _scale;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _scale = transform.localScale;
    }

    
    void Update()
    {
        if(!_isAllowPlayerInput) return;
        
        float horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
        float verticalInput = UnityEngine.Input.GetAxis("Vertical");
        
        if(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput)> 1)
        {
            horizontalInput *= 0.75f;
            verticalInput  *=  0.75f;
        }
        
        // Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * (Time.deltaTime * speed));
        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput) * _scale.x, _scale.y, _scale.z);
        }

        // Set the animation
        _animator.SetFloat(Speed, Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
    }


    private void OnEnable()
    {
        Input.OnInventoryPressed += () =>
        {
            _isAllowPlayerInput = false;
            _animator.SetFloat(Speed, 0);
            transform.localScale = _scale;
        };
        
        Input.OnCloseButtonPressed += () =>
        {
            _isAllowPlayerInput = true;
        };
    }
}

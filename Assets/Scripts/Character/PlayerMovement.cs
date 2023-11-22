using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
    
    private static readonly int Speed = Animator.StringToHash("Speed");
    
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private bool _isAllowPlayerInput = true;
    private Vector3 _scale;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _scale = transform.localScale;
    }

    
    void Update()
    {
        if(!_isAllowPlayerInput) return;

        Vector2 playerInput = GetPlayerInput();
        MovePlayer(playerInput);
        FlipPlayerSprite(playerInput.x);
        SetPlayerAnimationSpeed();
    }

    private Vector2 GetPlayerInput()
    {
        float horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
        float verticalInput = UnityEngine.Input.GetAxis("Vertical");

        if(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput) > 1)
        {
            horizontalInput *= 0.75f;
            verticalInput *= 0.75f;
        }

        return new Vector2(horizontalInput, verticalInput);
    }

    private void MovePlayer(Vector2 playerInput)
    {
        _rigidbody.velocity = playerInput * speed;
    }

    private void FlipPlayerSprite(float horizontalInput)
    {
        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput) * _scale.x, _scale.y, _scale.z);
        }
    }

    private void SetPlayerAnimationSpeed()
    {
        _animator.SetFloat(Speed, _rigidbody.velocity.magnitude / speed);
    }


    private void OnEnable()
    {
        PlayerInput.OnInventoryPressed += () =>
        {
            _isAllowPlayerInput = false;
            _animator.SetFloat(Speed, 0);
            transform.localScale = _scale;
        };
        
        PlayerInput.OnCloseButtonPressed += () =>
        {
            _isAllowPlayerInput = true;
        };
    }
}

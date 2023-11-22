using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 15.0f;
        [FormerlySerializedAs("healthManager")] [SerializeField] private PlayerHealthManager playerHealthManager;
    
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
            if(playerHealthManager.IsDead) return;

            Vector2 playerInput = GetPlayerInput();
            MovePlayer(playerInput);
            FlipPlayerSprite(playerInput.x);
            SetPlayerAnimationSpeed();
        }

        private Vector2 GetPlayerInput()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

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

        
        /// <summary>
        ///  This method is responsible for blocking player input when the game is paused.
        /// </summary>
        private void SetIsAllowPlayerInput(bool isPause)
        {
            if (isPause)
            {
                _isAllowPlayerInput = false;
                _rigidbody.velocity = Vector2.zero;
                _animator.SetFloat(Speed, 0);
                transform.localScale = _scale;
            }
            else
            {
                _isAllowPlayerInput = true;
            }
        }

        private void OnEnable()
        {
          GameUI.OnGamePaused += SetIsAllowPlayerInput;
        }
    }
}

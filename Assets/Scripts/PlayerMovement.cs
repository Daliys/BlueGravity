using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
    
    private static readonly int Speed = Animator.StringToHash("Speed");
    
    private Animator _animator;
    
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        if(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput)> 1)
        {
            horizontalInput *= 0.75f;
            verticalInput  *=  0.75f;
        }
        
        // Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * (Time.deltaTime * speed));
        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1, 1);
        }

        // Set the animation
        _animator.SetFloat(Speed, Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        print( Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
    }
}

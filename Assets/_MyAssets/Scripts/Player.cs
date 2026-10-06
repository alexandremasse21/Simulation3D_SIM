using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Déplacement")]
    [Tooltip("Vitesse de déplacement, en unités par seconde")]
    [SerializeField] private float _moveSpeed = 7f;
    [Tooltip("Vitesse de rotation, en degrés par seconde")]
    [SerializeField] private float _rotateSpeed = 720f;
    [Tooltip("Multiplie la gravité appliquée au joueur")]
    [SerializeField] private float _gravityScale = 2.5f;

    [Header("Références")]
    [Tooltip("Source des entrées du joueur")]
    [SerializeField] private GameInput _gameInput;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        Vector3 velocity = moveDir * _moveSpeed;
        velocity.y = _rb.linearVelocity.y;
        _rb.linearVelocity = velocity;

        Vector3 extraGravity = Physics.gravity * (_gravityScale - 1f);
        _rb.AddForce(extraGravity, ForceMode.Acceleration);

        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            _rb.MoveRotation(Quaternion.RotateTowards(
                _rb.rotation,
                targetRotation,
                _rotateSpeed * Time.fixedDeltaTime));
        }
    }
}
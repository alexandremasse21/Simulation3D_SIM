using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _rotateSpeed = 720f;
    [SerializeField] private GameInput _gameInput;

    private void Update()
    {
        Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += moveDir * _moveSpeed * Time.deltaTime;

        // LookRotation ne sait pas quoi faire d'un vecteur nul
        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                _rotateSpeed * Time.deltaTime);
        }
    }
}
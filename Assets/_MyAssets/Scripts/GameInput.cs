using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    // Awake et non Start : Player interroge GameInput dès le premier Update
    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
    }

    // L'Input System alloue des ressources natives à libérer explicitement
    private void OnDestroy()
    {
        _playerInputActions.Player.Disable();
        _playerInputActions.Dispose();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector.normalized;
    }
}

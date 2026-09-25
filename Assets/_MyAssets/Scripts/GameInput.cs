using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Disable();
    }

    /// <summary>
    /// Méthode qui retourne un vecteur 2 pour le déplacement du joueur
    /// </summary>
    /// <returns></returns>
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized; // Normaliser la valeur du vecteur

        return inputVector;
    }
}

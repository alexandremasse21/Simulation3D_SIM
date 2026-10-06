using UnityEngine;

public class FinishZone : MonoBehaviour
{
    private GameManager _gameManager;
    private bool _isReached;

    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isReached || !other.TryGetComponent<Player>(out _))
        {
            return;
        }

        _isReached = true;
        _gameManager.CompleteLevel();

        // Le joueur a récupéré le burger : is disparaît de la scène
        gameObject.SetActive(false);
    }
}

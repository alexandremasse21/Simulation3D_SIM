using UnityEngine;

public class FinishZone : MonoBehaviour
{
    private bool _isReached;

    private void OnTriggerEnter(Collider other)
    {
        if (_isReached || !other.TryGetComponent<Player>(out _))
        {
            return;
        }

        _isReached = true;
        GameManager.Instance.CompleteLevel();

        // Le joueur a récupéré le burger : is disparaît de la scène
        gameObject.SetActive(false);
    }
}

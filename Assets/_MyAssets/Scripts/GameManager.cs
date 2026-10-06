using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _hitCount;

    private void Start()
    {
        Debug.Log("Atteignez l'arrivée en touchant le moins d'obstacles.");
    }

    public void RegisterHit()
    {
        _hitCount++;
        Debug.Log($"Accrochages : {_hitCount}");
    }
}

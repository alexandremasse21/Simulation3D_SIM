using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _penaltyTime;

    private void Start()
    {
        Debug.Log("Atteignez l'arrivée en touchant le moins d'obstacles.");
    }

   /// <summary>
   /// Ajoute la pénalité de l'obstacle touché au temps du joueur.
   /// </summary>
   /// <param name="penaltySeconds"></param>
    public void RegisterHit(int penaltySeconds)
    {
        _penaltyTime += penaltySeconds;
        Debug.Log($"Pénalité : {_penaltyTime}");
    }

    /// <summary>
    /// Affiche le temps et le résultat du niveau qui vient de se terminer.
    /// </summary>
    public void CompleteLevel()
    {
        float duration = Time.timeSinceLevelLoad;
        float score = duration + _penaltyTime;
        Debug.Log($"Arrivée en {duration:F2} s, pénalité {_penaltyTime} s");
        Debug.Log($"Résultat : {score:F2} s");
    }
}

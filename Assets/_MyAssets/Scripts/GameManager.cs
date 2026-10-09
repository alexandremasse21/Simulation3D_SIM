using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private readonly List<LevelResult> _results = new List<LevelResult>();
    private int _penaltyTime;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Un GameManager existe déjà : il vient d'un niveau précédent
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

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
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        float duration = Time.timeSinceLevelLoad;
        _results.Add(new LevelResult(levelIndex, duration, _penaltyTime));
        _penaltyTime = 0; // Remet à 0 pour le prochain niveau

        int nextIndex = levelIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            ShowSummary();
        }
    }

    private void ShowSummary()
    {
        float total = 0f;
        foreach (LevelResult result in _results)
        {
            float score = result.Duration + result.Penalty;
            total += score;
            Debug.Log($"Niveau {result.LevelIndex + 1} : {result.Duration:F2} s, " + $"pénalité {result.Penalty} s, résultat {score:F2} s");
        }

        Debug.Log($"Résultat total : {total:F2} s");

        // La partie est finie: le joueur disparait, le reste du monde continue
        Player player = FindAnyObjectByType<Player>();
        if (player != null)
        {
            Destroy(player.gameObject);
        }
    }
}

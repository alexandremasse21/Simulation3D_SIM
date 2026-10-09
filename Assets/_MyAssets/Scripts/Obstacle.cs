using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Tooltip("Matériau appliqué à l'obstacle une fois touché")]
    [SerializeField] private Material _hitMaterial;
    [Tooltip("Secondes de pénalité quand le joueur touche cet obstacle")]
    [SerializeField] private int _penaltySeconds = 2;

    private Renderer _renderer;
    private bool _wasHit;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_wasHit || !collision.gameObject.TryGetComponent<Player>(out _))
        {
            return;
        }

        _wasHit = true;
        _renderer.sharedMaterial = _hitMaterial;
        GameManager.Instance.RegisterHit(_penaltySeconds);
    }
}

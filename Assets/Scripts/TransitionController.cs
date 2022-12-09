using UnityEngine;

public class TransitionController : MonoBehaviour
{
    [SerializeField] private TransitionPool _transitionPool;
    [SerializeField] private TransitionSpawn[] _transitionSpawn;

    private void Awake()
    {
        for (int i = 0; i < _transitionSpawn.Length; i++)
        {
            _transitionSpawn[i].OnSpawnData += SpawnTransition;
        }
        
    }
    private void OnDisable()
    {
        for (int i = 0; i < _transitionSpawn.Length; i++)
        {
            _transitionSpawn[i].OnSpawnData -= SpawnTransition;
        }
    }
    private void SpawnTransition(Vector3 position, DirectionTransition direction)
    {
        TransitionMove transition = _transitionPool.GetTransitionMove();
        transition.SpawnTransition(position, direction);
    }
    
}

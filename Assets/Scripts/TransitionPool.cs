using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TransitionPool : MonoBehaviour
{
    private Stack<TransitionMove> _transitionPool;
    [SerializeField] private List<TransitionMove> _transitionUse;
    [SerializeField] private int _countOfTransition;
    [SerializeField] private TransitionMove[] _transitionArray;

    private void Awake()
    {
        _transitionPool = new Stack<TransitionMove>();
        _transitionUse = new List<TransitionMove>();
        InitializePool();
    }
    private void OnDisable()
    {
        for (int i = 0; i < _transitionUse.Count; i++)
        {
            _transitionUse[i].OnDisableTransition -= PutTransitionToPool;
        }
    }
    private void InitializePool()
    {
        for (int i = 0; i < _countOfTransition; i++)
        {
            int transition = Random.Range(0, 7);
            _transitionPool.Push(Instantiate(_transitionArray[transition]));
        }
        
    }
    public TransitionMove GetTransitionMove()
    {
        TransitionMove transition = _transitionPool.Pop();
        _transitionUse.Add(transition);
        transition.OnDisableTransition += PutTransitionToPool;
        return transition;
    }

    public void PutTransitionToPool(TransitionMove transition)
    {
        transition.OnDisableTransition -= PutTransitionToPool;
        _transitionUse.Remove(transition);
        _transitionPool.Push(transition);
    }

    
}

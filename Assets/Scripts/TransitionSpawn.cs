using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum DirectionTransition
{
    Left,
    Right
}
public class TransitionSpawn : MonoBehaviour
{
    [SerializeField] private Transform _leftSpawn;
    [SerializeField] private Transform _rightSpawn;
    private float _timerLeft;
    private float _timerRight;
    private float _timeForSpawnLeftTransition;
    private float _timeForSpawnRightTransition;
    public Action<Vector3, DirectionTransition> OnSpawnData;
    private void Start()
    {
        OnSpawnData?.Invoke(_leftSpawn.position, DirectionTransition.Left);
        OnSpawnData?.Invoke(_rightSpawn.position, DirectionTransition.Right);
        _timeForSpawnLeftTransition = Random.Range(1.0f, 2.0f);
        _timeForSpawnRightTransition = Random.Range(1.0f, 2.0f);
    }

    
    private void Update()
    {
        SpawnLeftTransition();
        SpawnRightTransition();
    }

    private void SpawnLeftTransition()
    {
        if (_timerLeft > _timeForSpawnLeftTransition)
        {
            OnSpawnData?.Invoke(_leftSpawn.position, DirectionTransition.Left);
            _timeForSpawnLeftTransition = Random.Range(1.3f, 1.8f);
            _timerLeft = 0;
        }
        else
        {
            _timerLeft += Time.deltaTime;
        }

    }

    private void SpawnRightTransition()
    {
        if (_timerRight > _timeForSpawnRightTransition)
        {
            OnSpawnData?.Invoke(_rightSpawn.position, DirectionTransition.Right);
            _timeForSpawnRightTransition = Random.Range(1.3f, 1.8f);
            _timerRight = 0;
        }
        else
        {
            _timerRight += Time.deltaTime;
        }
    }
    
}

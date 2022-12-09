using UnityEngine;
using UnityEngine.UI;

public class DistanceToEnd : MonoBehaviour
{
    private Vector3 _startPosition;
    private float _distanceRoad;
    [SerializeField] private Transform _currentPosition;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private Slider _progressBar;
    

    private void Awake()
    {
        _startPosition = _currentPosition.position;
        _distanceRoad = _endPosition.position.x - _startPosition.x;
        _progressBar.maxValue = _distanceRoad;
    }

    private void Update()
    {
        float pathTaken = _currentPosition.position.x - _startPosition.x;
        _progressBar.value = pathTaken;
    }
}

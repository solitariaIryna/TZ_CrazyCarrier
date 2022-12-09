using System;
using UnityEngine;

public class TransitionMove : MonoBehaviour
{
    private float _speed = 8f;
    private bool _isMove = false;
    public Action<TransitionMove> OnDisableTransition;
   
    private void Update()
    {
        if (_isMove)
            transform.position += (new Vector3(0, 0, _speed * Time.deltaTime));

    }

    public void SpawnTransition(Vector3 positionSpawn, DirectionTransition directionTransition)
    {
        _isMove = true;
        transform.position = positionSpawn;
        if (directionTransition == DirectionTransition.Left)
        {
            transform.LookAt(transform.position + Vector3.back);
            _speed *= -1;
            
        }
        else
        {
            transform.LookAt(transform.position + Vector3.forward);
            _speed *= 1;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            Disable();
            OnDisableTransition?.Invoke(this);
        }
    }
    public void Disable()
    {
        _speed = Mathf.Abs(_speed);
        _isMove = false;
        transform.position = Vector3.zero;
    }
}

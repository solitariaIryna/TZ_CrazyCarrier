using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private GivePizza _givePizza;
    public Action OnLoseGame;
    public Action OnWinGame;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            _playerMove.StopMoving();
            _givePizza.ActiveGivePizzaClient();
            OnWinGame?.Invoke();
        }
        if (other.CompareTag("Transition") || other.CompareTag("Barrier"))
        {
            _playerMove.StopMoving();
            OnLoseGame?.Invoke();
        }
    }
}

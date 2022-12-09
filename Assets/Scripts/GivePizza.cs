using UnityEngine;

public class GivePizza : MonoBehaviour
{
    [SerializeField] private Transform _clientTransform;
    [SerializeField] private Transform _pizzaBoxTransform;
    private Vector3 _startPositionPizzaBox;
    private float _timer;
    private bool isGivePizza = false;
 
    private void Update()
    {
        if (isGivePizza)
        {
            GivePizzaToClient();
        }
    }
    public void ActiveGivePizzaClient()
    {
        isGivePizza = true;
        _startPositionPizzaBox = _pizzaBoxTransform.position;
    }

    private void GivePizzaToClient()
    {
        if (_timer < 1f)
        {
            _timer += Time.deltaTime;
            _pizzaBoxTransform.position = Vector3.Lerp(_startPositionPizzaBox, _clientTransform.position, _timer);
        }
        else
        {
            _timer = 0f;
            isGivePizza = false;
        }
    }
}

using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private CharacterController _characterController;
    private Vector3 _movement;
    private float _speed;
    private float _acceleration;
    private float _maxSpeed = 0.3f;
    private float _breaking;
    private bool _isMove = true;
    
    private void FixedUpdate()
    {
        if (_isMove)
        {
            if (_floatingJoystick.Horizontal > 0)
            {
                Acceleration();
            }
            else if (_floatingJoystick.Horizontal <= 0.01)
            {
                Brake();
            }
            Move();
        }
    }

    private void Acceleration()
    {
        _acceleration = Mathf.Clamp01(_acceleration + Time.deltaTime * 0.4f);
        _speed = Mathf.Clamp(_speed + _floatingJoystick.Horizontal * OutQuad(_acceleration) * Time.deltaTime, 0, _maxSpeed);
    }
    
    private void Brake()
    {
        if (_floatingJoystick.Horizontal != 0)
        {
            _breaking = Mathf.Clamp01(_breaking + Time.deltaTime * 0.4f);
            _acceleration = Mathf.Clamp01(_acceleration - Time.deltaTime);
            _speed = Mathf.Clamp(_speed - Mathf.Abs(_floatingJoystick.Horizontal) * OutQuad(_breaking) * Time.deltaTime, 0,
                _maxSpeed);
        }
        else
        {
            _speed = Mathf.Clamp(_speed - 0.1f * Time.deltaTime, 0,
                _maxSpeed);
        }
     
    }

    private void Move()
    {
        _movement  = new Vector3(_speed, 0, 0);
        _characterController.Move(_movement);
        
    }
    public void StopMoving()
    {
        _isMove = false;
    }
    
    private float OutQuad(float time)
    {
        time = Mathf.Clamp01(time);
        return -(time /= 1f) * (time - 2f);
    }
}

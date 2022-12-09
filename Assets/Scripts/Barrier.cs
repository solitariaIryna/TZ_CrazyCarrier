using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private Transform _blockRail;
    private bool _isOpen = true;
    private float _timer;
    private bool _isDelay = false;
    private float _delay;
    private Vector3 _rotationOpen;
    private Vector3 _rotationClose;


    private void Awake(){
        _rotationClose = _blockRail.transform.localEulerAngles;
        _rotationOpen = new Vector3(_rotationClose.x, _rotationClose.y , _rotationClose.z + 90f);
    }

    private void Update()
    {
        ActivateCloseOrOpenBarrier();
    }

    private void CloseBarrier(float timer){
        _blockRail.transform.localEulerAngles = Vector3.Lerp(_rotationOpen, _rotationClose, timer);
    }

    private void OpenBarrier(float timer){
        _blockRail.transform.localEulerAngles = Vector3.Lerp(_rotationClose, _rotationOpen, timer);
    }

    private void ActivateCloseOrOpenBarrier()
    {
        if(_isDelay)
        {
            if(_delay < 2f)
            {
                _delay += Time.deltaTime;
            }
            else
            {
                _isDelay = false;
                _delay = 0f;
            }
        }
        else
        {
            if (_isOpen)
            {
                if (_timer < 1f)
                {
                    _timer += Time.deltaTime * 0.5f;
                    OpenBarrier(_timer);
                }
                else
                {
                    _isDelay = true;
                    _isOpen = false;
                    _timer = 0f;
                }
            }
            else
            {
                if (_timer < 1f)
                {
                    _timer += Time.deltaTime * 0.5f;
                    CloseBarrier(_timer);
                }
                else
                {
                    _isDelay = true;
                    _isOpen = true;
                    _timer = 0f;
                }
            }
        }
    }
}

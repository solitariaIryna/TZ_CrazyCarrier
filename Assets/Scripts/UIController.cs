using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _panelLoseGame;
    [SerializeField] private GameObject _panelWinGame;
    [SerializeField] private GameObject _floatingJoystick;
    [SerializeField] private Button _buttonRestartGame;
    [SerializeField] private Button _buttonNextLevel;

    private void Awake()
    {
        _playerController.OnLoseGame += ActivateLoseMenu;
        _playerController.OnWinGame += ActivateWinMenu;
    }

    private void OnDisable()
    {
        _playerController.OnLoseGame -= ActivateLoseMenu;
    }
    
    private void ActivateLoseMenu()
    {
        _panelLoseGame.SetActive(true);
        _floatingJoystick.SetActive(false);
    }
    private void ActivateWinMenu()
    {
        _panelWinGame.SetActive(true);
        _floatingJoystick.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _floatingJoystick.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _floatingJoystick.SetActive(true);
    }

}

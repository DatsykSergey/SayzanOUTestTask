using Enemy;
using Input;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private GameObject _gameOverWindow;
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private Transform _camera;

    private void Awake()
    {
        _player.GetComponent<PlayerMovement>().Initialize(new JoystickInput(_joystick), _camera);
        
        EnemyInitialize(_player);
        UIInitialize(_player);
    }

    private void OnDisable()
    {
        _player.Death -= OnPlayerDeath;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    private void UIInitialize(PlayerHealth playerHealth)
    {
        playerHealth.Death += OnPlayerDeath;
        _gameOverWindow.SetActive(false);
    }

    private void EnemyInitialize(PlayerHealth playerHealth)
    {
        foreach (AttackPlayer attackPlayer in FindObjectsOfType<AttackPlayer>()) 
            attackPlayer.Initialize(playerHealth);
    }

    private void OnPlayerDeath()
    {
        _gameOverWindow.SetActive(true);
    }
}
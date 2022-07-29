using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{

    [Inject]
    private PlayerMovement _playerMovement;

    [SerializeField]private Transform _playerTransform;

    private void Update() {
        _playerMovement.PlayerMove(_playerTransform);
    }
}

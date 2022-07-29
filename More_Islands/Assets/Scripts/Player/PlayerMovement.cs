using UnityEngine;
using Zenject;


public class PlayerMovement 
{
    private PlayerInput _playerInput;
    private void Awake() {
        _playerInput = new PlayerInput();
    }

    private void OnEnable() {
        _playerInput.Enable();
    }

    private void OnDisable() {
        _playerInput.Disable();
    }
    public void PlayerMove(Transform transform){
        Debug.Log("its Work");
    }
}

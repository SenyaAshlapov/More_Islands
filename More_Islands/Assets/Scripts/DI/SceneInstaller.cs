using System.ComponentModel;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public PlayerMovement PlayerMovement;
    public override void InstallBindings()
    {
        playreBinding();
    }

    private void playreBinding()
    {
        Container.Bind<PlayerMovement>().FromInstance(PlayerMovement).AsSingle();

        
    }
}
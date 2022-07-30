using System.Net;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public PlayerMovement PlayerMovement;
    public PlayerAttack PlayerAttack;
    public override void InstallBindings()
    {
        playreBinding();
    }

    private void playreBinding()
    {
        Container.
            Bind<PlayerMovement>().
            FromInstance(PlayerMovement).
            AsSingle();

        Container.
            Bind<PlayerAttack>().
            FromInstance(PlayerAttack).
            AsSingle();
        
    }
}
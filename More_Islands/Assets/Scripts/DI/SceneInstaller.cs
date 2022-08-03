using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public Player Player;
    public PlayerMovement PlayerMovement;
    public PlayerAttack PlayerAttack;
    public PlayerAnimations PlayerAnimations;
    public override void InstallBindings()
    {
        playreBinding();
    }

    private void playreBinding()
    {
        Container.
            Bind<Player>().
            FromInstance(Player).
            AsSingle();

        Container.
            Bind<PlayerMovement>().
            FromInstance(PlayerMovement).
            AsSingle();

        Container.
            Bind<PlayerAttack>().
            FromInstance(PlayerAttack).
            AsSingle();

        Container.
            Bind<PlayerAnimations>().
            FromInstance(PlayerAnimations).
            AsSingle();              
        
    }

}
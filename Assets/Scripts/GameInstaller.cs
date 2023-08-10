using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class GameInstaller : MonoInstaller
{
    [SerializeField] private UIController _uiController;
    [SerializeField] private PlayerMovement _playerMovement;
    public override void InstallBindings()
    {
        Container.Bind<UIController>().FromInstance(_uiController).AsSingle().NonLazy();
        Container.Bind<PlayerMovement>().FromInstance(_playerMovement).AsSingle().NonLazy();
        Debug.Log("Container Building Complette");
    }
}

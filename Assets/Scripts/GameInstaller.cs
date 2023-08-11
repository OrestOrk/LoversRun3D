using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class GameInstaller : MonoInstaller
{
    [SerializeField] private UIController _uIController;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Transform _coinsFlyTransform;
    [SerializeField] private ProgressBar _progressBar;
    public override void InstallBindings()
    {
        Container.Bind<UIController>().FromInstance(_uIController).AsSingle().NonLazy();
        Container.Bind<PlayerMovement>().FromInstance(_playerMovement).AsSingle().NonLazy();
        Container.Bind<Transform>().FromInstance(_coinsFlyTransform).AsSingle().NonLazy();
        Container.Bind<ProgressBar>().FromInstance(_progressBar).AsSingle().NonLazy();
    }
}

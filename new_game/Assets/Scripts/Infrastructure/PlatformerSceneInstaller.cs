using UnityEngine;
using Zenject;

public class PlatformerSceneInstaller : MonoInstaller
{
    [SerializeField] private DialogView _dialogView;
    [SerializeField] private DialogData _dialogData;
    public override void InstallBindings()
    {
        Container.Bind<DialogHandler>()
            .FromNew()
            .AsSingle()
            .WithArguments(_dialogView, _dialogData)
            .NonLazy();
    }

    public override void Start()
    {
        Container.Resolve<DialogHandler>().StartDialog();
    }
}

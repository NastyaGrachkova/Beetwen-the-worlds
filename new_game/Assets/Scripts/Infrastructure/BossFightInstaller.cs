using UnityEngine;
using Zenject;

public class BossFightInstaller : MonoInstaller
{
    [SerializeField] private DialogView _dialogView;
    [SerializeField] private DialogData _dialogData;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private MonoBehaviourProcess _mono;
    [SerializeField] private bool _isNeedStartDialog;
    public override void InstallBindings()
    {
        Container.Bind<EventBus>()
            .FromNew()
            .AsSingle()
            .NonLazy();
        Container.Bind<DialogHandler>()
            .FromNew()
            .AsSingle()
            .WithArguments(_dialogView, _dialogData)
            .NonLazy();
        Container.Bind<AudioSource>()
            .FromInstance(_audioSource)
            .AsSingle()
            .NonLazy();
        Container.Bind<BossStateMachine>()
            .FromNew()
            .AsSingle()
            .WithArguments(_mono)
            .NonLazy();
    }

    public override void Start()
    {
        if (_isNeedStartDialog == true)
        {
            Container.Resolve<DialogHandler>().StartDialog();
        }
    }
}

using Zenject;
using Core.Loading;


public class ManagersInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SceneLoadingManager>().AsSingle();
    }
}

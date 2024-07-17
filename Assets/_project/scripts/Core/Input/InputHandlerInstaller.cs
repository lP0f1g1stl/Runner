using Zenject;
using Core.InputHandling;

public class InputHandlerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputHandlerKeboard>().AsSingle();
    }
}

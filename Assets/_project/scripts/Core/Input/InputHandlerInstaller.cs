using Zenject;
using Core.InputHandling;
using UnityEngine;

public class InputHandlerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        if (Application.isMobilePlatform)
        {
            Container.BindInterfacesAndSelfTo<InputHandlerKeboard>().AsSingle();
        }
        else
        {
            Container.BindInterfacesAndSelfTo<InputHandlerKeboard>().AsSingle();
        }
    }
}

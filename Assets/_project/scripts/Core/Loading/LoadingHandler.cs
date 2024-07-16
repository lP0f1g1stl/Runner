using UnityEngine;
using UnityEngine.UI;
using Core.Loading;
using Zenject;

namespace Core.Loading
{
    public class LoadingHandler : MonoBehaviour
    {
        private Slider loadingBar;
        private SceneLoadingManager sceneLoadingManager;

        [Inject]
        public void Construct(SceneLoadingManager sceneLoadingManager)
        {
            this.sceneLoadingManager = sceneLoadingManager;
        }
        private void Awake()
        {
            loadingBar = GetComponent<Slider>();
        }
        private void OnEnable()
        {
            sceneLoadingManager.OnProgressChange += ChangeValue;
        }
        private void ChangeValue(float value) 
        {
            Debug.Log(value);
            loadingBar.value = value;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using Core.Loading;
using Zenject;

namespace Core.Loading
{
    public class LoadingHandler : MonoBehaviour
    {
        private Slider _loadingBar;
        private SceneLoadingManager _sceneLoadingManager;

        [Inject]
        public void Construct(SceneLoadingManager sceneLoadingManager)
        {
            this._sceneLoadingManager = sceneLoadingManager;
        }
        private void Awake()
        {
            _loadingBar = GetComponent<Slider>();
        }
        private void OnEnable()
        {
            _sceneLoadingManager.OnProgressChange += ChangeValue;
        }
        private void ChangeValue(float value) 
        {
            Debug.Log(value);
            _loadingBar.value = value;
        }
    }
}

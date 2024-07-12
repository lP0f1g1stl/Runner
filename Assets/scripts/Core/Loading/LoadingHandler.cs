using UnityEngine;
using UnityEngine.UI;

namespace Core.Loading
{
    public class LoadingHandler : MonoBehaviour
    {
        private Slider loadingBar;

        private void Awake()
        {
            loadingBar = GetComponent<Slider>();
        }
        public void ChangeValue(int value) 
        {
            loadingBar.value = value;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tanks
{
    public class SceneMan : MonoBehaviour
    {
        public void PlayLevel2()
        {
            SceneManager.LoadScene("Tanks2");
        }

        public void PlayLevel()
        {
            SceneManager.LoadScene("Tanks");
        }

        public void PlayMenu()
        {
            SceneManager.LoadScene("MenuScene");
        }

        public void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE_WIN && !UNITY_EDITOR
            Application.Quit();
#endif
        }
    }
}



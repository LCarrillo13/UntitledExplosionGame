using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameScripts.MenuScripts
{
    public class SceneLoad : MonoBehaviour
    {
        public void LoadScene(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    //[SerializeField] private TransitionSettings _transition;
    //[SerializeField] private float _delay = 0.5f;

    public void LoadScene(string sceneName)
    {
        //TransitionManager.Instance().Transition(sceneName, _transition, _delay);
    }

    public void ReloadScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        //TransitionManager.Instance().Transition(sceneName, _transition, _delay);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

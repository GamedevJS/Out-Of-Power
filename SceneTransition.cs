using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public void StartScene(string sceneName)
    {
        GetComponentInChildren<Animator>().SetTrigger("SceneEnd");

        StartCoroutine(ReallyStartScene(sceneName));
    }

    private IEnumerator ReallyStartScene(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public Animator blackoutAnim;

    private void Start()
    {
        blackoutAnim.SetTrigger("In");
    }

    public void LoadScene(int sceneId)
    {
        StartCoroutine(SceneChange(sceneId));
    }

    public void LoadScene(string sceneId)
    {
        StartCoroutine(SceneChange(sceneId));

    }

    public void RestartScene()
    {
        StartCoroutine(SceneChange(SceneManager.GetActiveScene().buildIndex));
    }

    public void Quit()
    {
       Application.Quit();
    }

    IEnumerator SceneChange(int sceneID)
    {
        blackoutAnim.SetTrigger("Out");
        yield return new WaitForSeconds(blackoutAnim.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(sceneID);

    }
    IEnumerator SceneChange(string sceneID)
    {
        blackoutAnim.SetTrigger("Out");
        yield return new WaitForSeconds(blackoutAnim.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(sceneID);

    }

}

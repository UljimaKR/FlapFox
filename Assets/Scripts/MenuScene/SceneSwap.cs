using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public void GameStart()
    {
        StartCoroutine("Delay");
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Lv01_Test");
    }
}

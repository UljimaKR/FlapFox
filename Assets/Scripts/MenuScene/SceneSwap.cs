using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public Camera mainCam;
    Vector3 camOffset_Settings = new Vector3(3.1f, 0, 0);
    Vector3 camBasePos = new Vector3(0.1f, 2.3f, 3.3f);


    public void GameStart()
    {
        StartCoroutine("LoadDelay");
    }


    public IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Lv01");
        // Play an audio effect here
    }



    public void CallSettings()
    {
        StopCoroutine("offsetMain");
        StartCoroutine("offsetSettings");
    }

    public IEnumerator offsetSettings()
    {
        float duration = 4f;

        while (duration > 0)
        {
            duration -= Time.deltaTime;
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, new Vector3(camOffset_Settings.x, mainCam.transform.position.y, mainCam.transform.position.z), 5f * Time.deltaTime);
            yield return null;
        }
    }



    public void CallMainMenu()
    {
        StopCoroutine("offsetSettings");
        StartCoroutine("offsetMain");
    }

    public IEnumerator offsetMain()
    {
        float duration = 4f;

        while (duration > 0)
        {
            duration -= Time.deltaTime;
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camBasePos, 5f * Time.deltaTime);
            yield return null;
        }
    }




    public void CloseGame()
    {
        Application.Quit();
    }
}

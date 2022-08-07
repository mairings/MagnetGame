using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIFuncs : MonoBehaviour
{
    int _nextSceneLoad;
    private void Start()
    {
        _nextSceneLoad = SceneManager.GetActiveScene().buildIndex+1;
    }
    public void PasifFunc(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void ActiveFunc(GameObject obj)
    {
        obj.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        if (_nextSceneLoad == 9) { SceneManager.LoadSceneAsync(0); return; }

            if (_nextSceneLoad > PlayerPrefs.GetInt("Level"))
            {

                PlayerPrefs.SetInt("Level", _nextSceneLoad);

                SceneManager.LoadSceneAsync(_nextSceneLoad);


            }
            else
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            }

    }

    public void PauseGame(GameObject continueButton)
    {
        continueButton.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }
    public void ContinueGame(GameObject pauseButton)
    {   
        pauseButton.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void SceneLoad(int indexScene)
    {
        SceneManager.LoadSceneAsync(indexScene);
    }


}

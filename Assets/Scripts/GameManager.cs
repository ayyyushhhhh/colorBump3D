using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  [SerializeField]GameObject Panel;

  public void pause()
  {
    Time.timeScale=0f;
  Panel.SetActive(true);
  }
  public void resume()
  {
      Time.timeScale=1f;
        Panel.SetActive(false);
  }
  public void menu()
  {Time.timeScale=1f;
    SceneManager.LoadScene(0);
  }
public void Play()
{
  Debug.Log(PlayerPrefs.GetInt("Level"));
  if(PlayerPrefs.GetInt("Level")==-1)
  SceneManager.LoadScene(1);
  else{
  SceneManager.LoadScene(PlayerPrefs.GetInt("Level")+1);
}
}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenuHandler : MonoBehaviour
{
  public TextMeshProUGUI bestScoreText;

  private void Start() {
    if(BestScoreManager.Instance) {
      BestScoreManager.Instance.loadBestScore();
      bestScoreText.text = "Best Score: " + BestScoreManager.Instance.bestScoreName + " : " + BestScoreManager.Instance.bestScore;
    }
  }
  public void StartGame()
  {
    SceneManager.LoadScene(1);
  }

  public void Quit()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
  }
}

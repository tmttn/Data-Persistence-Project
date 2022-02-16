using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
  public static BestScoreManager Instance { get; private set; }
  public string bestScoreName;
  public int bestScore;

  private void Awake()
  {
    if (!Instance)
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
    }

    DontDestroyOnLoad(this);
  }

  [System.Serializable]
  class BestScore
  {
    public string name;
    public int score;
  }

  public void saveBestScore()
  {
    BestScore bestScore = new BestScore();
    bestScore.name = this.bestScoreName;
    bestScore.score = this.bestScore;

    string json = JsonUtility.ToJson(bestScore);
    File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
  }

  public void loadBestScore()
  {
    string path = Application.persistentDataPath + "/saveFile.json";
    if (File.Exists(path))
    {
      string json = File.ReadAllText(path);
      BestScore bestScore = JsonUtility.FromJson<BestScore>(json);

      this.bestScoreName = bestScore.name;
      this.bestScore = bestScore.score;
    }
  }
}

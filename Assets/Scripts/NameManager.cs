using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameManager : MonoBehaviour
{
  public static NameManager Instance { get; private set; }
  public string playerName { get; set; }

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
}

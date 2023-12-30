using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
   void OnEnable()
    {
        SceneManager.LoadScene("Sample Scene 2", LoadSceneMode.Single);
    }
}

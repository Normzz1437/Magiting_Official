using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
     void OnEnable()
    {
        //Only specifying the sceneName or sceneBuildIndex will load
        SceneManager.LoadScene("Bata_test", LoadSceneMode.Single);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OBB_NEXTSCENELOADER : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Main Menu Scene", LoadSceneMode.Single);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevelOne()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadSceneAsync(0);
    }
}

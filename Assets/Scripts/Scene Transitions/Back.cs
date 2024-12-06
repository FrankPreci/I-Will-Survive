using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelUi : MonoBehaviour
{
    public void Back () {
        Debug.Log("Main Menu");
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//startScene 1: start에 적용
public class start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //엔터를 누르면 게임 시작
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("toystorytelling");
        }
    }
}

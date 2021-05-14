using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//gameoverScene: gameover에 적용

public class gameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CameraController.retry=false;
    }

    // Update is called once per frame
    void Update()
    {
        jump.gameover = false;
        jump.play = true;
        movearm.ok = false;
        movearm.reverse = false;
        dooropen.angle = -1;
        //enter누르면 게임 시작
        if (Input.GetKeyDown(KeyCode.Return))
        {
           
            SceneManager.LoadScene("toystorytelling");
        }
        
    }
}

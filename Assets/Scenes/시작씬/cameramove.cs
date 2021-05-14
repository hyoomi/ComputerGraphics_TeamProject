using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//startScene 1: first, second, third 카메라에 적용
public class cameramove : MonoBehaviour
{

    GameObject first;       //첫번째 카메라
    GameObject second;      //두번째 카메라
    GameObject third;       //세번째 카메라
    GameObject text;        //"press Enter to restart" 글자
    private Animator ani;   //lookaroundController
    public static bool doormove;       //startdoor.cs에서 사용
    public static bool looking;     //lookaround모션을 제어하는 변수
    int moving;             //시간 경과를 나타내는 변수

    public void showfirst()     //첫번째 카메라 on
    {
        first.GetComponent<Camera>().enabled = true;
        second.GetComponent<Camera>().enabled = false;
        third.GetComponent<Camera>().enabled = false;
    }

    public void showsecond()    //두번째 카메라 on
    {
        first.GetComponent<Camera>().enabled = false;
        second.GetComponent<Camera>().enabled = true;
        third.GetComponent<Camera>().enabled = false;
    }

    public void showthird()     //세번째 카메라 on
    {
        first.GetComponent<Camera>().enabled = false;
        second.GetComponent<Camera>().enabled = false;
        third.GetComponent<Camera>().enabled = true;
    }


    void Start()
    {
        //변수 초기화
        first = GameObject.Find("first");
        second = GameObject.Find("second");
        third = GameObject.Find("third");
        text = GameObject.Find("startText");
        ani = gameObject.GetComponent<Animator>();
        doormove = false;
        looking = false;
        moving = 0;
        //start
        jump.gameover = false;
        jump.doing = false;
        showfirst();        //첫번째 카메라 on
    }


    void Update()
    {
        moving++;
        //first카메라가 +Z축 방향으로 이동
        if (moving < 80)
        {
            transform.Translate(0, 0, 0.5f);
        }

        //문 열리는 소리 재생
        else if (moving == 80)
        {
            GameObject.Find("door set").GetComponent<AudioSource>().Play();
        }

        //두번째 카메라 on
        else if (moving < 240)
        {
            showsecond();       
            doormove = true;
            GameObject.Find("cabinet").GetComponent<AudioSource>().Play();  //"it's story time~" 오디오 재생
            if (moving == 140)
                looking = true;
        }

        //세번째 카메라 on
        else if (moving < 360)
        {
            doormove = false;
            showthird();        
        }

        else
        {
            //text가 우디 머리 위에 나타난다
            if (looking == true)
            {
                text.transform.Translate(new Vector3(0, 800f, 0));

            }
            looking = false;
            jump.doing = true;
        }

    }
}
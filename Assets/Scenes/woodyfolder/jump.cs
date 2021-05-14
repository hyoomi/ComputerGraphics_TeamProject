using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//toystorytelling: Idle(우디)에 적용
public class jump : MonoBehaviour
{

    public static Animator ani;   //Idle model(woody Controller)
    float jumpForce = 9.9f; //jump force
    float LRForce = 16.0f;  //left right jump force
    bool first = true;  //우디가 서랍 0층을 올라갈때 true
    bool soundcheck;
    public static bool checkDown;   //죽은 척할때 true인 변수(movearm에서 사용)
    public static int[] cab = new int[10];    //cabinet 배열. cab[층] = 열리는 서랍
    public static int posX; //우디의 현재 position. 서랍 왼쪽부터 1, 2, 3, 4
    public static int posY; //우디의 현재 층수. 바닥은 -1. 가장 밑서랍부터 0층
    public static bool play; //다른 동작을 제한하는 변수(우디가 낙하할때 키보드 입력과 문열림 제한)
    public static bool gameover;   
    public static bool fall;
    public static bool doing;
    public static bool jumping; //우디가 점프하면 true(cabinetMove에서 사용)
    public static bool caught; //들키면 true(movearm에서 사용)
    float height;       //우디의 높이. 바닥에 부딪히는 모션을 play할 때 사용


    void Start()
    {
        //변수 초기화
        soundcheck = false;
        checkDown = false;
        play = true; //다른 동작을 제한하는 변수(우디가 낙하할때 키보드 입력과 문열림 제한)
        gameover = false;
        fall = false;
        doing = true;
        jumping = false;
        caught = false;
        posX = 1; //우디의 현재 position. 서랍 왼쪽부터 1, 2, 3, 4
        posY = -1;
        ani = gameObject.GetComponent<Animator>();
    }

    void jumpUp()   //+Y축 이동
    {
        transform.position += Vector3.up * jumpForce;
    }

    void jumpFront()    //+Z축 이동
    {
        transform.Translate(new Vector3(0, 0, 10));
    }

    void jumpRight()    //오른쪽 점프
    {
        transform.position += Vector3.up * jumpForce;
        transform.position += Vector3.right * LRForce;
    }

    void jumpLeft()     //왼쪽 점프
    {
        transform.position += Vector3.up * jumpForce;
        transform.position += Vector3.left * LRForce;
    }

    void gameoverdelay()
    {
        gameover = true;
    }

    void falldelay()
    {
        fall = true;
    }

    void finishdelay()
    {
        ani.SetBool("jump", false);             
        SceneManager.LoadScene("finishScene");
    }

    void Update()
    {
        //캐비넷 잘못 밟으면 떨어진다
        if (fall == true)
        {
            if (soundcheck == false)
            {
                //떨어지는 효과음
                GameObject.Find("Idle").GetComponent<AudioSource>().Play();
                soundcheck = true;
            }
            //떨어지는 모션 시작
            ani.SetBool("fall", true);
            transform.Translate(new Vector3(0, -150, 0) * Time.deltaTime);
            height = transform.position.y;
            //바닥에 부딪히는 모션. 딜레이 후 gameoverScene으로 넘어간다
            if (height < 20.0f)
            {
                ani.SetBool("fall", false);
                fall = false;
                Invoke("gameoverdelay", 4.0f);               
            }

        }

        //들켰다(movearm.cs)=>CameraController.cs
        if(caught == true)
        {
            ani.SetBool("jump", false);
           ani.SetBool("caught", true);
        }
        else
        {
            ani.SetBool("caught", false);
        }

        //게임오버 씬으로 넘어간다: 바닥에 떨어졌다 or 들켰다
        if (gameover == true)
        {
            SceneManager.LoadScene("gameoverScene");
        }

        //도착하면 finishScene으로 넘어간다
        if(posY==10)
	    {
		    doing=false;	
		    SceneManager.LoadScene("finishScene");
	    }

        //키보드 입력
        if (play == true)
        {
            //UP키가 눌렸을때
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                posY++;
                if (posY == 10)
                {
                   
                }
                else if(posY > -1)
                {
                    //우디가 점프하는 모션을 취하고 위로 올라간다
                    jumping = true;
                    ani.SetBool("jump", true);
                    checkDown = false;
                    Invoke("jumpUp", 0.40f);
                    Invoke("jumpUp", 0.43f);
                    Invoke("jumpUp", 0.46f);
                    Invoke("jumpUp", 0.49f);
                    Invoke("jumpUp", 0.51f);
                    Invoke("jumpUp", 0.54f);
                    Invoke("jumpUp", 0.57f);
                    Invoke("jumpUp", 0.61f);
                    Invoke("jumpUp", 0.64f);
                    //첫번째 칸일 경우 올라가면서 전진한다
                    if (first)
                    {
                        Invoke("jumpFront", 0.51f);
                        Invoke("jumpFront", 0.54f);
                        Invoke("jumpFront", 0.57f);
                        Invoke("jumpFront", 0.61f);
                        first = false;
                    }
                    //잘못된 칸을 밟으면 떨어질거다
                    if (cab[posY] != posX)
                    {
                        play = false;
                        Invoke("falldelay", 0.5f);
                    }
                }
            }//finish GetKeyDown(Up)

            //UP키가 올리올때
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                //우디:idle모션
                ani.SetBool("jump", false);
            }//finish GetKeyUp(Up)


            //Down키가 눌렸을때
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //우디:뒤로 눕는 모션
                ani.SetBool("down", true);
                checkDown = true;
            }//finish GetKeyDown(Down)

            //Down키가 올라올때
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                //우디: 일어나는 모션
                ani.SetBool("jump", false);
                ani.SetBool("down", false);
                checkDown = false;
            }//finish GetKeyUp(Down)


            //Right키가 눌렸을때
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                posX++; posY++;
                if (posY == 10)
                {
                    
                }
                else if (posY > -1)
                {
                    //우디:오른쪽 점프
                    jumping = true;
                    ani.SetBool("jump", true);
                    checkDown = false;
                    Invoke("jumpRight", 0.40f);
                    Invoke("jumpRight", 0.43f);
                    Invoke("jumpRight", 0.46f);
                    Invoke("jumpRight", 0.49f);
                    Invoke("jumpRight", 0.51f);
                    Invoke("jumpRight", 0.54f);
                    Invoke("jumpRight", 0.57f);
                    Invoke("jumpRight", 0.61f);
                    Invoke("jumpRight", 0.64f);
                    //잘못된 칸을 밟으면 떨어질거다
                    if (cab[posY] != posX)
                    {
                        play = false;
                        Invoke("falldelay", 0.5f);
                    }
                }
            }//finish GetKeyDown(Right)

            //Right키가 올라올때
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                ani.SetBool("jump", false);
            }//finish GetKeyUp(Right)


            //Left키가 눌렸을때
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                posX--; posY++;
                if (posY == 10)
                {
                   
                }
                else if (posY > -1)
                {
                    //우디:왼쪽 점프
                    jumping = true;
                    ani.SetBool("jump", true);
                    checkDown = false;
                    Invoke("jumpLeft", 0.40f);
                    Invoke("jumpLeft", 0.43f);
                    Invoke("jumpLeft", 0.46f);
                    Invoke("jumpLeft", 0.49f);
                    Invoke("jumpLeft", 0.51f);
                    Invoke("jumpLeft", 0.54f);
                    Invoke("jumpLeft", 0.57f);
                    Invoke("jumpLeft", 0.61f);
                    Invoke("jumpLeft", 0.64f);
                    //잘못된 칸을 밟으면 떨어질거다
                    if (cab[posY] != posX)
                    {
                        play = false;
                        Invoke("falldelay", 0.5f);
                    }
                }
            }//finish GetKeyDown(Left)

            //Left키가 올라올때
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                ani.SetBool("jump", false);

            }//finish GetKeyUP(Left)
        } //finish if(play == true)
    }//finish Update()
}
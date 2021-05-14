using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//toystorytelling: cabinet:openblock0에 적용
public class cabinetMove : MonoBehaviour
{
    int currY;
    float[] cabLoc = new float[5]; //씬에서 캐비넷이 열릴 때 X값 저장 
    int nextX; 
    int nextY;
    int beforeY;
    float nextLoc;
    GameObject[] openblocks = new GameObject[10];
    // Start is called before the first frame update
    void Start()
    {
        //변수 초기화
        cabLoc[0] = 0.0f; cabLoc[1] = -0.36f; cabLoc[2] = -0.12f;
        cabLoc[3] = 0.12f; cabLoc[4] = 0.36f;
        this.openblocks[0] = GameObject.Find("openblock0");
        this.openblocks[1] = GameObject.Find("openblock1");
        this.openblocks[2] = GameObject.Find("openblock2");
        this.openblocks[3] = GameObject.Find("openblock3");
        this.openblocks[4] = GameObject.Find("openblock4");
        this.openblocks[5] = GameObject.Find("openblock5");
        this.openblocks[6] = GameObject.Find("openblock6");
        this.openblocks[7] = GameObject.Find("openblock7");
        this.openblocks[8] = GameObject.Find("openblock8");
        this.openblocks[9] = GameObject.Find("openblock9");

        //랜덤으로 열릴 서랍 결정
        jump.cab[0] = 1; jump.cab[1] = 2;
        for (currY = 1; currY < 9; currY++)
        {
            if (jump.cab[currY] == 1)
            {
                jump.cab[currY + 1] = 2;
            }
            else if (jump.cab[currY] == 4)
            {
                jump.cab[currY + 1] = 3;
            }
            else
            {
                if (Random.Range(0, 2) == 0) //0,1 
                {
                    jump.cab[currY + 1] = jump.cab[currY] - 1;
                }
                else
                {
                    jump.cab[currY + 1] = jump.cab[currY] + 1;
                }
            }
        }
    }
    void opencabenit()
    {
        this.openblocks[nextY].transform.Translate(new Vector3(0, 0, -3.5f) * 3); //서랍이 열린다.
    }
    void closecabenit()
    {
        this.openblocks[beforeY].transform.Translate(new Vector3(0, 0, 3.5f) * 3); //서랍이 닫힌다.
    }

    // Update is called once per frame
    void Update()
    {
        //우디 1층 위의 캐비넷을 열자
        if (jump.posY < 9 && jump.jumping == true)
        {
            GameObject.Find("openblock0").GetComponent<AudioSource>().Play();
            nextY = jump.posY + 1;  //몇층 열릴거야?
            nextX = jump.cab[nextY];    //몇번째 서랍 열릴거야?
            nextLoc = cabLoc[nextX] - (-0.36f);   //열릴 서랍의 실제 X좌표값(씬)
            this.openblocks[nextY].transform.Translate(new Vector3(nextLoc * 600, 0, 0)); //열릴 위치로 이동
            Invoke("opencabenit", 0.0f);
            Invoke("opencabenit", 0.05f);
            Invoke("opencabenit", 0.1f);
            Invoke("opencabenit", 0.15f);
            Invoke("opencabenit", 0.2f);
            Invoke("opencabenit", 0.25f);
            Invoke("opencabenit", 0.3f);
            Invoke("opencabenit", 0.35f);
            Invoke("opencabenit", 0.4f);
            Invoke("opencabenit", 0.45f);
            

            beforeY = jump.posY - 1;
            if(beforeY >= 0)
            {
                Invoke("closecabenit", 0.3f);
                Invoke("closecabenit", 0.35f);
                Invoke("closecabenit", 0.4f);
                Invoke("closecabenit", 0.45f);
                Invoke("closecabenit", 0.50f);
                Invoke("closecabenit", 0.55f);
                Invoke("closecabenit", 0.6f);
                Invoke("closecabenit", 0.65f);
                Invoke("closecabenit", 0.7f);
                Invoke("closecabenit", 0.75f);
            }



            jump.jumping = false;

        }
    }
}

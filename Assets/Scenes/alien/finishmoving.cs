using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//finishScene alein에 적용
public class finishmoving : MonoBehaviour
{
	public float speed=2.7f;
	private bool up=true;
	private int switcha=-1;

    // Update is called once per frame
    void Update()
    {
        //알린이 랜덤하게 점프한다
		if(switcha>-1&&switcha<50&&up==true)
		{
			transform.Translate(new Vector3(0,1.3f,0)*speed);
			switcha++;
		}
		else if(switcha==50)
		{
			up=false;
			switcha--;
		}
		else if(switcha>-1)
		{
			transform.Translate(new Vector3(0,-1.3f,0)*speed);
			switcha--;
		}
		else
		{
			 if(jump.doing==false&&Random.Range(0,50)==0)
			{
			up=true;
			switcha++;
			}
		}
	
    }
}

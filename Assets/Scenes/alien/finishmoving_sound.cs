using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//finishScene: alein(7)에 적용
public class finishmoving_sound : MonoBehaviour
{
	public float speed=0.7f;
	private bool up=true;
	private int switcha=-1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
		if(switcha>-1&&switcha<150&&up==true)
		{
			transform.Translate(new Vector3(0,1.3f,0)*speed);
			switcha++;
		}
		else if(switcha==150)
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
			//박수와 환호 오디오를 재생한다.
			if (jump.doing == false)
			{
				GameObject.Find("alein (7)").GetComponent<AudioSource>().Play();
				up = true;
				switcha++;
			}
		}
	
    }
}

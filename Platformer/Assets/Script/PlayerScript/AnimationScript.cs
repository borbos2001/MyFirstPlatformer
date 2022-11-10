using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] Animator Anim;
    void Update()
    {

    }
    public void FlyAnim(float _velocityPlayerY)
    {
        Anim.SetFloat("velocity.y", _velocityPlayerY);
    }
    public void JampAnimation(bool OnTheGraund)
    {
        Anim.SetBool("Jamp",!OnTheGraund);
        
    }
    public void RunAnimation(float speed)
    {
        Anim.SetFloat("speed",speed);
    }
    public void SitAnimation(bool _sit,float _speed)
    {
        Anim.SetFloat("speed",_speed);
        Anim.SetBool("Sit",_sit);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager Instance;
    public Animator blackScreenAnimator;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Fade out
    public void FadeFromBlack()
    {

    }
    //Fade in
    public void ToggleFade() {
        blackScreenAnimator.SetTrigger("Fade");
    }
}

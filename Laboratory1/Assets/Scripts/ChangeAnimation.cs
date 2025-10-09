using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Distance : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;

    public RuntimeAnimatorController idleController;
    public RuntimeAnimatorController fightController;

    private GameObject maleCharacter;
    private GameObject femaleCharacter;

    private Animator maleAnimator;
    private Animator femaleAnimator;

    // Start is called before the first frame update
    void Start()
    {
        maleCharacter = target1.transform.GetChild(0).gameObject;
        femaleCharacter = target2.transform.GetChild(0).gameObject;

        maleAnimator = maleCharacter.GetComponent<Animator>();
        femaleAnimator = femaleCharacter.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target1.transform.position, target2.transform.position);

        if (distance < 0.1)
        {

            if (maleAnimator && fightController)
            {
                maleAnimator.runtimeAnimatorController = fightController;
            }

            if (femaleAnimator && fightController)
            {
                femaleAnimator.runtimeAnimatorController = fightController;
            }

        }

        else
        {
            if (maleAnimator && idleController)
            {
                maleAnimator.runtimeAnimatorController = idleController;
            }

            if (femaleAnimator && idleController)
            {
                femaleAnimator.runtimeAnimatorController = idleController;
            }
        }
    }
}
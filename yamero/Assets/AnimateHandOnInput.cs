using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{

    [SerializeField]
    private InputActionProperty pinchAnimationAction;

    [SerializeField] 
    private InputActionProperty gripAnimationAction;

    [SerializeField]
    private Animator handAnimator;

    
    private void Update()
    {
        float triggerVal = pinchAnimationAction.action.ReadValue<float>(); // the value is of type AXIS so it reads how much the button is 
                                                                           // pressed --> it returns a value of type float
                                                                           // if it was of type bool, it only checked if the button is being pressed or not

        // Debug.Log(triggerVal);
        handAnimator.SetFloat("Trigger", triggerVal);

        float gripVal = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripVal);

        Debug.Log("Pedoro migeru san teve negativa no teste, ESTUDASSES");
    }
}

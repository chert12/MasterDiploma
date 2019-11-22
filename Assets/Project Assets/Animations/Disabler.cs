using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AAStudio.Diploma.Animations
{
	public class Disabler : StateMachineBehaviour
	{

		[SerializeField] private string _booleanVariableName;

		// OnStateExit is called when a transition ends and the state 
		//machine finishes evaluating this state
		override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.SetBool(_booleanVariableName, false);
		}
	}
}

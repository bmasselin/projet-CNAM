using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[AddComponentMenu("Playground/Conditions/Condition Collision")]
[RequireComponent(typeof(Collider))]
public class ConditionCollision : ConditionBase
{

	//This will create a dialog window asking for which dialog to add
	private void Reset()
	{
		Utils.ColliderDialogWindow(this.gameObject, false);
	}
	
	// This function will be called when something touches the trigger collider
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.CompareTag(filterTag)
			|| !filterByTag)
		{
			ExecuteAllActions(collision.gameObject);
		}
	}
}

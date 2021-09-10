using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TriggerCutsceneZone : MonoBehaviour {

	[SerializeField] UnityEvent triggerEvent;
	[SerializeField] Collider2D triggerArea;

	bool triggered = false;

	void OnTriggerEnter2D(Collider2D col){
		if (!triggered && col.tag == "Player"){
			print("Trigger Entered");
			triggerEvent.Invoke();
			triggered = true;
		}
	}

	public void NextScene(){
		if (!(triggered = Statics.TryLoadNextScene())){
			Debug.Log("HERE MEANS ITS LAST SCENE");
			return;	//if false, this is the last scene
		}
		Debug.Log("HERE MEANS ITS NOT LAST SCENE");
	}

	public void EnableTriggerArea(){
		triggerArea.enabled = true;
	}

}

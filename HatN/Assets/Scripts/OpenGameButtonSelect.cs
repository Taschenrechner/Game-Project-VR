using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenGameButtonSelect : MonoBehaviour {
	
	void Start(){
		//sorgt dafür, dass das Hauptmenü geladen wird, sobald der rechte Trigger gedrückt wird
		GameObject.Find("WelcomeButton").GetComponent<Button>().Select();
	}
}

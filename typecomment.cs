using UnityEngine;
using System.Collections;

public class typecomment : MonoBehaviour {
	public GameObject textbox;
	public GameObject textbox1;
	public GameObject textbox2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);   
			
			RaycastHit hit = new RaycastHit ();
			
			if (Physics.Raycast (ray, out hit)) {
				
				if (hit.collider.gameObject == gameObject) {

					textbox.SendMessage("change_string",this.getType());
					textbox1.SendMessage ("change_string",this.getHealth().ToString());
					textbox2.SendMessage("change_string",this.getAttack().ToString());
					
				}
				
			}
		
		}
	}
}

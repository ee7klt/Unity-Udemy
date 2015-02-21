using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {





	public Text text;
	private enum States { cell, sheets_0, mirror, lock_0, sheets_1, cell_mirror, lock_1, corridor_0, stairs_0, floor, closet_door, stairs_1, corridor_1, 
						in_closet, stairs_2, corridor_2, courtyard, corridor_3 };
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if 		(myState == States.cell) { cell ();}
		else if (myState == States.sheets_0) { sheets_0 ();}
		else if (myState == States.mirror) { mirror ();}
		else if (myState == States.lock_0) { lock_0 ();}
		else if (myState == States.cell_mirror) { cell_mirror ();}
		else if (myState == States.sheets_1) { sheets_1 ();}
		else if (myState == States.lock_1) { lock_1 ();}
		else if (myState == States.corridor_0) { corridor_0 ();}
		else if (myState == States.stairs_0) { stairs_0 ();}
		else if (myState == States.floor) { floor ();}
		else if (myState == States.closet_door) { closet_door ();}
		
		
		
	}
	
	void cell () {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press [S] to view Sheets, [M] to view Mirror and [L] to view Lock" ;
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_0;
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			myState = States.mirror;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_0;
		}
	}
	
	void sheets_0 () {
		text.text = "Some dirty sheets\n\n" +
					"Press [R] to Return to your cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void mirror () {
		text.text = "A broken mirror\n\n" +
			"Press [R] to Return to your cell, [T] to take the mirror";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.cell_mirror;
		}
	}
	
	void lock_0 () {
		text.text = "The lock to the cell\n\n" +
			"Press [R] to Return to your cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void cell_mirror () {
		text.text = "You now hold a shiny mirror in your hands\n\n" +
			"Press [S] to use the mirror on your sheets and [L] to use the mirror on the lock";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_1;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_1;
		}
	}
	
	void sheets_1 () {
		text.text = "The dirty sheets\n\n" +
			"Press [R] to Return to your cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	
	void lock_1 () {
		text.text = "The lock to the cell\n\n" +
			"Press [O] to open the lock to the cell, [R] to return to your cell";
		if (Input.GetKeyDown (KeyCode.O)) {
			myState = States.corridor_0;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	
	void corridor_0 () {
		text.text = "You have escaped the cell and now stand in a dimly lit corridor. All around you is silent. " +
					"A flight of stairs rises domineeringly in front of you in to darkness. And to your left " +
					"stands an old closet\n\n" +
					"Press [S] to silently creep up the stairs, [F] to look at the floor, or [C] to open the closet";
		if (Input.GetKeyDown (KeyCode.S)) { myState = States.stairs_0; }
		else if (Input.GetKeyDown (KeyCode.F)) { myState = States.floor; }
		else if (Input.GetKeyDown (KeyCode.C)) { myState = States.closet_door; }
	}
	
	void stairs_0 () {
		text.text = "You walk up the stairs and bump your nose on a concrete wall at the very top.\n\n" +
					"Press [R] to return to the corridor";
		if (Input.GetKeyDown (KeyCode.R)) { myState = States.corridor_0; }
	}
	
	void floor () {
		text.text = "Squinting in the dim lighting, you spot a shiny object on the floor. "+
					"Upon closer inspection, you see that it is a hair pin." +
					"Press [H] to pick up hair pin, [R] to return to corridor";
		if (Input.GetKeyDown (KeyCode.H)) { myState = States.cell; }
		else if (Input.GetKeyDown (KeyCode.R)) { myState = States.corridor_0; }
	}
	
	void closet_door () {
		text.text = "An old closet door";
		if (Input.GetKeyDown (KeyCode.R)) { myState = States.corridor_0; }
	}
	
	

	
	
}

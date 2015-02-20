using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {





	public Text text;
	private enum States { cell, sheets_0, mirror, lock_0, sheets_1, cell_mirror, lock_1, freedom };
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.cell) {
			state_cell ();
		}
		if (myState == States.sheets_0) {
			state_sheets_0 ();
		}
		if (myState == States.mirror) {
			state_mirror ();
		}
		if (myState == States.lock_0) {
			state_lock_0 ();
		}
		if (myState == States.cell_mirror) {
			state_cell_mirror ();
		}
		if (myState == States.sheets_1) {
			state_sheets_1 ();
		}
		if (myState == States.lock_1) {
			state_lock_1 ();
		}
		if (myState == States.freedom) {
			state_freedom ();
		}
		
	}
	
	void state_cell () {
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
	
	void state_sheets_0 () {
		text.text = "Some dirty sheets\n\n" +
					"Press [R] to Return to your cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void state_mirror () {
		text.text = "A broken mirror\n\n" +
			"Press [R] to Return to your cell, [T] to take the mirror";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.cell_mirror;
		}
	}
	
	void state_lock_0 () {
		text.text = "The lock to the cell\n\n" +
			"Press [R] to Return to your cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void state_cell_mirror () {
		text.text = "You now hold a shiny mirror in your hands\n\n" +
			"Press [S] to use the mirror on your sheets and [L] to use the mirror on the lock";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_1;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_1;
		}
	}
	
	void state_sheets_1 () {
		text.text = "The dirty sheets\n\n" +
			"Press [R] to Return to your cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	
	void state_lock_1 () {
		text.text = "The lock to the cell\n\n" +
			"Press [O] to open the lock to the cell, [R] to return to your cell";
		if (Input.GetKeyDown (KeyCode.O)) {
			myState = States.freedom;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	
	void state_freedom () {
		text.text = "Congratulations, you are free!!\n\n" +
			"Press [G] to play agin";
		if (Input.GetKeyDown (KeyCode.G)) {
			myState = States.cell;
		}
	}
	
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static int PlayerScore1 = 3;
	public static int hitpoints = 0;

	public GUISkin layout;

	GameObject theBall;

	// Use this for initialization
	void Start () {
		theBall = GameObject.FindGameObjectWithTag ("Ball");
	}

	public static void Score(string wallID) {
		
		
		if (wallID == "BottomWall")
		{
			PlayerScore1 --;
		} 
		else
		{
			hitpoints++;
		}
	}

	void OnGUI() {
		GUI.skin = layout;
		GUI.Label (new Rect (Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
		GUI.Label (new Rect (Screen.width / 2 + 150 + 12, 20, 100, 100), "" + hitpoints);

		if (GUI.Button (new Rect (Screen.width / 2 - 60, 35, 120, 53), "RESTART")) {
			PlayerScore1 = 3;
			hitpoints = 0;
			theBall.SendMessage ("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
		}

		if (PlayerScore1 == 0) 
		{
			GUI.Label (new Rect (Screen.width / 2 - 150, 200, 2000, 1000), "YOU LOSE!");
			theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		} 
		else if (hitpoints == 3) 
		{
			GUI.Label (new Rect (Screen.width / 2 - 150, 200, 2000, 1000), "YOU WIN!");
			theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		}
	}

}

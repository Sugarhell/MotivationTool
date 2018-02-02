using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MotivationTimer : EditorWindow {

	static float saveTime = 10.0f;
	static double nextSave = 0;

	static int autoSaveLabel = 1;

	[MenuItem("Examples/Simple autoSave")]
	static void Init()
	{
		MotivationTimer window = (MotivationTimer)GetWindowWithRect (
			                         typeof(MotivationTimer),
			                         new Rect (0, 0, 160, 60));
		window.Show ();
	}

	void OnGUI(){

		EditorGUI.LabelField(new Rect(10, 10, 80, 20), "Save Each:");
		EditorGUI.LabelField(new Rect(80, 10, 80, 20), saveTime + " secs");

		double timeToSave = nextSave - EditorApplication.timeSinceStartup;


		EditorGUI.LabelField(new Rect(10, 30, 80, 20), "Next Save:");
		EditorGUI.LabelField(new Rect(80, 30, 80, 20), timeToSave.ToString("N1") + " secs");

		this.Repaint();

		if (EditorApplication.timeSinceStartup > nextSave)
		{
			MotivationPopUP.Initiatize ();
			nextSave = EditorApplication.timeSinceStartup + saveTime;
			Debug.Log("Saved Scene: " + name);
		}

	}




}

public class MotivationPopUP: EditorWindow {

	public static bool ShowPopUP = false;

	public static void Initiatize()
	{
		MotivationPopUP windowPop = ScriptableObject.CreateInstance<MotivationPopUP>();
		windowPop.position = new Rect(Screen.width / 2, Screen.height / 2, 150, 150);
		windowPop.Show ();
	}

	void OnGUI(){

		EditorGUILayout.LabelField("This is an example of EditorWindow.ShowPopup", EditorStyles.wordWrappedLabel);
		GUILayout.Space(100);
		if (GUILayout.Button("Agree!")) this.Close();

	}
}

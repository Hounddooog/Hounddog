using UnityEngine;
using System.Collections;

public class AutoType : MonoBehaviour 
{
	
	public float letterPause = 0.2f;
	public AudioClip sound;
	
	string message;
	
	// Use this for initialization
	void Start () 
	{
		message = GetComponent<GUIText>().text;
		GetComponent<GUIText>().text = "";
		StartCoroutine(TypeText ());
	}
	
	IEnumerator TypeText () 
	{
		foreach (char letter in message.ToCharArray()) 
		{
			GetComponent<GUIText>().text += letter;
			if (sound)
				GetComponent<AudioSource>().PlayOneShot (sound);
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}      
	}
}
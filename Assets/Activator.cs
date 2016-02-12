using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

    bool isPrompted = false;
    bool isLookingAtRecordPlayer = false;

	// Use this for initialization
	void Start () {
        print("transform.position = " + transform.position);	
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 5))
        {
            print("There is something in front of the object! - " + hit.collider.gameObject);

            if (hit.collider.gameObject.name == "record_player")
            {
                print("It's the record player!");
                isLookingAtRecordPlayer = true;

                // capture keyboard input and activate record player
                if (Input.GetKeyUp("e"))
                {
                    if (hit.collider.gameObject.GetComponent<RecordPlayer>().recordPlayerActive == false)
                    {
                        hit.collider.gameObject.GetComponent<RecordPlayer>().recordPlayerActive = true;
                    }
                    else
                    {
                        hit.collider.gameObject.GetComponent<RecordPlayer>().recordPlayerActive = false;
                    }
                }
            }
            else
            {
                isLookingAtRecordPlayer = false;
            }
        }
        else {
            isLookingAtRecordPlayer = false;
        }

        Debug.DrawRay(transform.position, fwd);
    }

    void OnGUI()
    {
        if (isLookingAtRecordPlayer && !isPrompted)
        {
            GUI.skin.label.onNormal.textColor = Color.white;
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 120, 20), "Press E to activate record player");
            //isPrompted = true;
        }

    }
}

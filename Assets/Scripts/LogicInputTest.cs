using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Input Description
1. Aiming: 
    Thrustmaster Throttle Flip X:
        -1: Left
        0: Center
        1: Right
    Thrustmaster Throttle Flip:
        -1: Down
        0: Center
        1: Up
2. Movement:
    Thrustmaster Throttle Elv:
        -1: Down
        0: Center
        1: Up
    Thrustmaster Throttle Roll:
        -1: Left
        0: Center
        1: Right
    Thrustmaster Throttle Pitch:
        -1: Forward
        0: Center
        1: Backward
    Thrustmaster Throttle Yaw:
        -1: Left
        0: Center
        1: Right
    Thrustmaster Throttle Speed:
        -1: Slow
        0: Center
        1: Fast
    Button 4: Up
    Button 5: Down


*/




public class LogicInputTest : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0 + i))
            {
                Debug.Log("JoystickButton + " + i);
            }
        }

        // if (Input.GetAxis("Thrustmaster Throttle Elv") != 0)
        // {
        //     Debug.Log("Thrustmaster Throttle Elv: " + Input.GetAxis("Thrustmaster Throttle Elv"));
        // }

        // if (Input.GetAxis("Thrustmaster Throttle Roll") != 0)
        // {
        //     Debug.Log("Thrustmaster Throttle Roll: " + Input.GetAxis("Thrustmaster Throttle Roll"));
        // }

        // if (Input.GetAxis("Thrustmaster Throttle Pitch") != 0)
        // {
        //     Debug.Log("Thrustmaster Throttle Pitch: " + Input.GetAxis("Thrustmaster Throttle Pitch"));
        // }

        // if (Input.GetAxis("Thrustmaster Throttle Yaw") != 0)
        // {
        //     Debug.Log("Thrustmaster Throttle Yaw: " + Input.GetAxis("Thrustmaster Throttle Yaw"));
        // }

        // if (Input.GetAxis("Thrustmaster Throttle Flip") != 0)
        // {
        //     Debug.Log("Thrustmaster Throttle Flip: " + Input.GetAxis("Thrustmaster Throttle Flip"));
        // }

        // if (Input.GetAxis("Thrustmaster Throttle Flip X") != 0)
        // {
        //     Debug.Log("Thrustmaster Throttle Flip X: " + Input.GetAxis("Thrustmaster Throttle Flip X"));
        // }

        // if (Input.GetAxis("Thrustmaster Throttle Speed") != 0)
        // {
        //     Debug.Log("Thrustmaster Throttle Speed: " + Input.GetAxis("Thrustmaster Throttle Speed"));
        // }
    }
}

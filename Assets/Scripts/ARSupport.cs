using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ARSupport : MonoBehaviour
{
    // Start is called before the first frame update
    public ARSession session;
    public Text txtOutput;

    private void OnEnable()
    {
        StartCoroutine(CheckSupport());
    }
    IEnumerator CheckSupport()
    {
        txtOutput.text = "Checking.....";

        yield return ARSession.CheckAvailability();

        switch (ARSession.state)
        {
            
            case ARSessionState.Unsupported:
                txtOutput.text = "AR Core Unsupported";
                break;
            case ARSessionState.NeedsInstall:
                txtOutput.text = "AR Core Needs Install";
                break;
            case ARSessionState.Ready:
                txtOutput.text = "AR Core Ready";
                break;
            default:
                txtOutput.text = "Non-AR Device";
                break;
        }

    }
}

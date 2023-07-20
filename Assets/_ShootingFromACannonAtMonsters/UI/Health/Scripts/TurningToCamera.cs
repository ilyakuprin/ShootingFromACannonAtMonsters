using System.Collections;
using UnityEngine;

public class TurningToCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        StartCoroutine(Turn());
    }

    private IEnumerator Turn()
    {
        mainCamera = Camera.main;

        while (true)
        {
            Quaternion camereRotation = mainCamera.transform.rotation;
            Quaternion currentRotation = transform.rotation;
            transform.rotation = new Quaternion(currentRotation.x,
                                                camereRotation.y, 
                                                currentRotation.z, 
                                                camereRotation.w);
            yield return null;
        }
    }
}

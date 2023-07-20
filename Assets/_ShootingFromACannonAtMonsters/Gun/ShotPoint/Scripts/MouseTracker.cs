using System.Collections;
using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class MouseTracker : MonoBehaviour
    {
        private Camera _camera;
        private readonly float _depthPlane = 10;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            StartCoroutine(FollowMouse());
        }

        private IEnumerator FollowMouse()
        {
            while (true)
            {
                Vector3 mouseScreenPosition = Input.mousePosition;
                Vector3 mousePlanePosition = new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, _depthPlane);
                Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(mousePlanePosition);

                transform.LookAt(mouseWorldPosition);

                yield return null;
            }
        }
    }
}

using System.Collections;
using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class FieldRotation : MonoBehaviour
    {
        [SerializeField, Range(50, 100)] private float _speed;

        private void Start()
        {
            StartCoroutine(RotateField());
        }

        private IEnumerator RotateField()
        {
            while (true)
            {
                float inputAxis = Input.GetAxisRaw(StringFieldInput.Horizontal);
                if (inputAxis > 0)
                {
                    transform.rotation *= Quaternion.Euler(0, _speed * Time.deltaTime, 0);
                }
                else if (inputAxis < 0)
                {
                    transform.rotation *= Quaternion.Euler(0, -_speed * Time.deltaTime, 0);
                }

                yield return null;
            }
        }
    }
}

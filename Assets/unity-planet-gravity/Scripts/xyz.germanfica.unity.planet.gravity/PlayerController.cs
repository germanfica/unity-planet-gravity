using UnityEngine;
using System.Collections;

namespace xyz.germanfica.unity.planet.gravity
{
    public class PlayerController : MonoBehaviour
    {
        public Rigidbody rig;
        RaycastHit hit;

        void Start()
        {
            rig.useGravity = false; // Disables Gravity
            rig.constraints = RigidbodyConstraints.FreezeRotation;
        }

        void Update()
        {
            if (Physics.Raycast(transform.position, -transform.up, out hit))
            {
                Debug.DrawLine(transform.position, hit.point, Color.cyan);
            }
        }

        void FixedUpdate()
        {
            Move();
        }

        /* Character movement
         */
        private void Move()
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }
    }
}
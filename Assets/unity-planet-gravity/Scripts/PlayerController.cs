/*******************************************************************************************
* Author: German L.G Fica
* Websites: http://germanfica.xyz
* Description: Basic character controller to walk around a planet.
*******************************************************************************************/
using UnityEngine;
using System.Collections;

namespace xyz.germanfica.unity.planet.gravity
{
    public class PlayerController : MonoBehaviour
    {
        public Rigidbody rig;
        RaycastHit hit;
        public bool freezeRotation = true;

        public int forceConst = 4;
        private bool canJump;

        void Start()
        {
            Ini();
        }

        void Update()
        {
            // Raycast (doesn't affect gameplay)
            if (Physics.Raycast(transform.position, -transform.up, out hit))
            {
                Debug.DrawLine(transform.position, hit.point, Color.cyan);
            }
            // Jump Action
            if (Input.GetKeyUp(KeyCode.Space))
            {
                canJump = true;
            }
        }

        void FixedUpdate()
        {
            Move();
            Jump();
        }

        /* Some initializations
         */
        private void Ini()
        {
            rig.useGravity = false; // Disables Gravity
            if (freezeRotation)
            {
                rig.constraints = RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                rig.constraints = RigidbodyConstraints.None;
            }
        }

        /* Character jump
         */
        private void Jump()
        {
            if (canJump)
            {
                canJump = false;
                // AddForce (useless)
                //rig.AddForce(0, forceConst, 0, ForceMode.Impulse);
                // AddForceAtPosition (useless too)
                //rig.AddForceAtPosition(new Vector3(0, 0, forceConst), rig.transform.position, ForceMode.Impulse);
                // AddRelativeForce (successful)
                rig.AddRelativeForce(0, forceConst, 0, ForceMode.Impulse);
            }
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
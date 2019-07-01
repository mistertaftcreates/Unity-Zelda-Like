using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeoLuz.PropertyAttributes;

namespace LeoLuz.PlugAndPlayJoystick
{
    public class SimpleController : MonoBehaviour
    {
        public string HorizontalAxis = "Horizontal";
        public string JumpAxis = "Jump";
        public string FireAxis = "Fire 1";
        public GameObject Projectile;
        Rigidbody2D rb;
        public float velocity = 5f;
        public float ProjectileVelocity = 7f;
        [ReadOnly]
        public bool grounded;
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        //void OnGUI()
        //{
        //    GUILayout.BeginVertical();
        //    GUILayout.Label("Input.GetButtonDown(FireAxis)=" + Input.GetButtonDown(FireAxis));
        //    GUILayout.Label(Input.GetButtonDownList());
        //    GUILayout.EndVertical();
        //}

        // Update is called once per frame
        void Update()
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocity, rb.velocity.y);

            if (grounded && Input.GetButtonDown(JumpAxis))
            {
                rb.velocity = new Vector2(rb.velocity.x, 10f);
                grounded = false;
            }
            if (Input.GetButtonDown(FireAxis))
            {
                GameObject obj = (GameObject)Instantiate(Projectile, transform.position + Vector3.right * 0.3f, Quaternion.identity);
                Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(ProjectileVelocity, 0f);
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            grounded = true;
        }

        void OnCollisionStay2D(Collision2D col)
        {
            grounded = true;
        }

        void OnCollisionExit2D(Collision2D col)
        {
            grounded = false;
        }
    }
}
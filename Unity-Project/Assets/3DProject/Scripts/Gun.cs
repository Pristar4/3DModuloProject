using Cinemachine;
using UnityEngine;

namespace StarterAssets
{
    public class Gun : MonoBehaviour
    {
        public float damage = 10f;

        public float range = 100f;

        //private StarterAssetsInputs _input;
        public Camera fpsCam;
        [SerializeField] CinemachineVirtualCamera aimVirtualCamera;
        [SerializeField] private Transform weaponout;

        private StarterAssetsInputs starterAssetsInputs;

        private void Awake()

        {
            starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        }

        private void Update()
        {
            //TODO Replace with New Input System

            #region Shoot_new_System

            /*// Shoot
            if (_input.isTrigger)
            {
                Shoot();
            }
            


            else
            {
                _input.jump = false;
            }*/

            #endregion

            // aimVirtualCamera.gameObject.SetActive(starterAssetsInputs.aim);

            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }

            if (starterAssetsInputs.aim)
            {
                aimVirtualCamera.gameObject.SetActive(true);
            }
            else
            {
                aimVirtualCamera.gameObject.SetActive(false);
            }
        }

        private void OnDrawGizmos()
        {
        }

        void Shoot()
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                Debug.DrawLine(weaponout.position, hit.point, Color.red, 2);


                Debug.Log(hit.transform.name);
            }
        }
    }
}
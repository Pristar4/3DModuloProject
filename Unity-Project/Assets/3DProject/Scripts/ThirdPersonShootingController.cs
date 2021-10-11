using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace _3DProject.Scripts
{
    public class ThirdPersonShootingController : MonoBehaviour
    {
        [SerializeField] private Transform aimTarget;
        [SerializeField] private GameObject armAim;


        [SerializeField] private Camera fpsCam;
        [SerializeField] CinemachineVirtualCamera aimVirtualCamera;
        [SerializeField] private Transform weaponout;
        private readonly float damage = 10f;

        private readonly float range = 100f;

        private Rig rig;

        private StarterAssetsInputs starterAssetsInputs;

        private void Awake()

        {
            rig = armAim.GetComponentInParent<Rig>();

            fpsCam = Camera.main;
            starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        }

        private void Update()
        {
            //TODO Replace with New Input System

            RaycastHit hit;


            #region Aim + Shoot

            //calculate ray from camera towards crosshair
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range) &&
                Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }

            if (starterAssetsInputs.aim)
            {
                if (hit.point == Vector3.zero)
                {
                    rig.weight = 0;
                }
                else
                {
                    rig.weight = 1;
                }

                aimTarget.position = hit.point;

                Vector3 hitPoint = hit.point;
                var transform1 = transform;
                var position = transform1.position;
                hitPoint.y = position.y;
                Vector3 aimDirection = (hitPoint - position).normalized;

                transform.forward = Vector3.Lerp(transform1.forward, aimDirection, Time.deltaTime * 20f);


                aimVirtualCamera.gameObject.SetActive(true);
            }
            else
            {
                rig.weight = 0;
                aimVirtualCamera.gameObject.SetActive(false);
            }

            #endregion
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
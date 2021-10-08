using Cinemachine;
using StarterAssets;
using UnityEngine;

namespace _3DProject.Scripts
{
    public class ThirdPersonShooterControler : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
        [SerializeField] private float normalSensitivity;
        [SerializeField] private float aimSensitivity;

        private ThirdPersonController _thirdPersonController;
        private StarterAssetsInputs _starterAssetsInputs;

        private void Awake()
        {
            _thirdPersonController = GetComponent<ThirdPersonController>();
            _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        }

        private void Update()
        {
            if (_starterAssetsInputs.aim)
            {
                _thirdPersonController.SetSensitivity(aimSensitivity);
                aimVirtualCamera.gameObject.SetActive(true);
            }
            else
            {
                _thirdPersonController.SetSensitivity(normalSensitivity);
                aimVirtualCamera.gameObject.SetActive(false);
            }
        }
    }
}
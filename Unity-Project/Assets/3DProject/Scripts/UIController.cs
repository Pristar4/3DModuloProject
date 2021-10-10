using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

namespace _3DProject.Scripts
{
    public class UIController : MonoBehaviour
    {
        
        // New UI TOOLKIT
        /*private Button _startButton;
        private Button _messageButton;
        private Label _messageText; 
    
    
        // Start is called before the first frame update
        private void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            
            _startButton = root.Q<Button>("start-button");
            _messageButton = root.Q<Button>("message-button");
            _messageText = root.Q<Label>("message-text");

            _startButton.clicked += StartButtonPressed;
            _messageButton.clicked += MessageButtonPressed;
        


        }

        public void StartButtonPressed()
        {
    
            SceneManager.LoadScene($"game");

        }
        void MessageButtonPressed()
        {
            _messageText.text = "Hello World";
            _messageText.style.display = DisplayStyle.Flex;

        }

  */
        // OLD UI SYSTEM
        
        public void StartButtonPressed()
        {
    
            SceneManager.LoadScene($"game");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
        
    }
    
}

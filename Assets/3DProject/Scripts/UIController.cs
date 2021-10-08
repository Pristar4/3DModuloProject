using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace _3DProject.Scripts
{
    public class UIController : MonoBehaviour
    {
        private Button _startButton;
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

        void StartButtonPressed()
        {
    
            SceneManager.LoadScene($"game");

        }
        void MessageButtonPressed()
        {
            _messageText.text = "Hello World";
            _messageText.style.display = DisplayStyle.Flex;

        }

  
    }
}

using UnityEngine;

namespace InteractableObj
{
    public abstract class Interactable : MonoBehaviour
    {
        protected GameObject Player;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ActionEvent.ChangeHintText(GetHintTextOnCollide());
                PlayerInput.OnInteractPressed += Interact;
                Player = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ActionEvent.ChangeHintText("");
                PlayerInput.OnInteractPressed -= Interact;
                Player = null;
            }
        }

        private void OnDisable()
        {
            PlayerInput.OnInteractPressed -= Interact;
            Player = null;
            
        }

        protected abstract string GetHintTextOnCollide();
        protected abstract void Interact();

    }
}

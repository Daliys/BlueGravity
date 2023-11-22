using UnityEngine;

namespace InteractableObj
{
    public abstract class Interactable : MonoBehaviour
    {
        protected GameObject InteractableGameObject;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                InteractableGameObject = other.gameObject;
                ActionEvent.ChangeHintText(GetHintTextOnCollide());
                PlayerInput.OnInteractPressed += Interact;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ActionEvent.ChangeHintText("");
                PlayerInput.OnInteractPressed -= Interact;
                InteractableGameObject = null;
            }
        }

        private void OnDisable()
        {
            PlayerInput.OnInteractPressed -= Interact;
            InteractableGameObject = null;
            
        }

        protected abstract string GetHintTextOnCollide();
        protected abstract void Interact();

    }
}

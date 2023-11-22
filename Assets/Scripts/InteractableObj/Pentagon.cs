using Character;
using UnityEngine;

namespace InteractableObj
{
    /// <summary>
    ///   Pentagon is an interactable object that can be activated by player. Activated pentagon will teleport player to the linked pentagon.
    /// </summary>
    public class Pentagon : Interactable
    {
        [SerializeField] private Pentagon linkedPentagon;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite activated;
        
        private bool _isActivated;
        

        protected override void Interact()
        {
            if (_isActivated) TeleportPlayer();
            else ActivatePentagons();
        }

        private void ActivatePentagons()
        {
            Activate();
            linkedPentagon.Activate();
            ActionEvent.ChangeHintText(GetHintTextOnCollide());
        }

        private void TeleportPlayer()
        {
            InteractableGameObject.transform.position = linkedPentagon.transform.position;
        }

        private void Activate()
        {
            _isActivated = true;
            spriteRenderer.sprite = activated;
            
            if (InteractableGameObject)
            {
                InteractableGameObject.GetComponent<PlayerHealthManager>()?.TakeDamage(1);
            }
        }
        
        protected override string GetHintTextOnCollide()
        {
            return _isActivated ? GameStrings.PentagonActivated : GameStrings.PentagonNotActivated;
        }
    }
}
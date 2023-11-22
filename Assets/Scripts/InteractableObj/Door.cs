namespace InteractableObj
{
    public class Door : Interactable
    {
        protected override string GetHintTextOnCollide()
        {
            return GameStrings.InteractWithDoor;
        }

        protected override void Interact()
        {
             ActionEvent.ChangeHintText(GameStrings.DoorIsLocked);
        }
    }
}
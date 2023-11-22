using UnityEngine;

namespace Character
{
    /// <summary>
    ///  This class is responsible for changing the skin of the character.
    /// </summary>
    public class SkinChanger : MonoBehaviour
    {
        [SerializeField] private SkinsInfo skinsInfo;
        
        [SerializeField] private SpriteRenderer head;
        [SerializeField] private SpriteRenderer face;
        [SerializeField] private SpriteRenderer hood;
        
        [SerializeField] private SpriteRenderer leftWrist;
        [SerializeField] private SpriteRenderer leftWeapon;
        [SerializeField] private SpriteRenderer leftElbow;
        [SerializeField] private SpriteRenderer leftShoulder;
        
        [SerializeField] private SpriteRenderer rightWrist;
        [SerializeField] private SpriteRenderer rightWeapon;
        [SerializeField] private SpriteRenderer rightElbow;
        [SerializeField] private SpriteRenderer rightShoulder;
        
        [SerializeField] private SpriteRenderer torso;
        
        [SerializeField] private SpriteRenderer leftBoot;
        [SerializeField] private SpriteRenderer leftLeg;
        
        [SerializeField] private SpriteRenderer rightBoot;
        [SerializeField] private SpriteRenderer rightLeg;
        
        [SerializeField] private SpriteRenderer pelvis;


       
        public void ChangeSkin(SkinID skinId)
        {
            var skin = skinsInfo.skins[(int) skinId];
            ChangeSkin(skin);
        }
        
        
        private void ChangeSkin(SkinData newSkin)
        {
            hood.sprite = newSkin.hood;
            
            leftWrist.sprite = newSkin.leftWrist;
            leftElbow.sprite = newSkin.leftElbow;
            leftShoulder.sprite = newSkin.leftShoulder;
            
            rightWrist.sprite = newSkin.rightWrist;
            rightElbow.sprite = newSkin.rightElbow;
            rightShoulder.sprite = newSkin.rightShoulder;
            
            torso.sprite = newSkin.torso;
            
            leftBoot.sprite = newSkin.leftBoot;
            leftLeg.sprite = newSkin.leftLeg;
            
            rightBoot.sprite = newSkin.rightBoot;
            rightLeg.sprite = newSkin.rightLeg;
            
            pelvis.sprite = newSkin.pelvis;
        }
        
        
    }
}
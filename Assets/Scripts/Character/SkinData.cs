using System;
using UnityEngine;

namespace Character
{
   
    [Serializable]
    public class SkinData 
    {
        public SkinID skinID;
        
        public Sprite hood;
        
        public Sprite leftWrist;
        public Sprite leftElbow;
        public Sprite leftShoulder;
        
        public Sprite rightWrist;
        public Sprite rightElbow;
        public Sprite rightShoulder;
        
        public Sprite torso;
        
        public Sprite leftBoot;
        public Sprite leftLeg;
        
        public Sprite rightBoot;
        public Sprite rightLeg;
        
        public Sprite pelvis;
    }
}
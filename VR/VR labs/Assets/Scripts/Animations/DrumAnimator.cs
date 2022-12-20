using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Animations
{
    public class DrumAnimator : MonoBehaviour
    {

        [SerializeField]
        private float duration;
    
        [SerializeField]
        private GameObject drum;
        [SerializeField]
        private GameObject disk;

        private Vector3 _diskStartPosition;

        private void Awake()
        {
            _diskStartPosition = disk.transform.position;
        }

        [Button]
        public void DoBeatAnimation()
        {
            //scale the drum up and then down
            drum.transform.DOScale(new Vector3(1.1f, 1f, 1.1f), duration/2).OnComplete(() =>
            {
                drum.transform.DOScale(1f, duration/2);
            });
            
            //move the disk relatively up and then down
            disk.transform.DOMove(_diskStartPosition + (Vector3.up*0.3f), duration/2).OnComplete(() =>
            {
                disk.transform.DOMove(_diskStartPosition, duration/2);
            });
        }
    }
}

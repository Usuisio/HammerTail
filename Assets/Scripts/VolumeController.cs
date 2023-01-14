using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class VolumeController : MonoBehaviour
{
    [SerializeField] float VignetteIntension;
    [SerializeField] Volume _volume;
    [SerializeField] Bloom _bloom;
    
    // Start is called before the first frame update
    void Start()
    {
        _volume = this.GetComponent<Volume>();
       _volume.profile.TryGet(out _bloom);

        DOTween.To(
            () => _bloom.intensity.value,
            num => _bloom.intensity.value = num,
            0.3f,
            4f
            )
            .SetEase(Ease.InOutCubic)
            .SetLoops(-1, LoopType.Yoyo);

        DOTween.To(
            () => _bloom.threshold.value,
            num => _bloom.threshold.value = num,
            0.3f,
            5f
            )
            .SetEase(Ease.InOutCubic)
            .SetLoops(-1, LoopType.Yoyo);
    }
}

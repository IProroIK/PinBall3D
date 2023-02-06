using UnityEngine;
using DG.Tweening;
public class Tile : MonoBehaviour
{
    [SerializeField] private float _animDuration;
    [SerializeField] private Vector3 _minScale;
    [SerializeField] private Vector3 _maxScale;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Win _win;

    private void OnEnable()
    {
        _win.OnWin += StartWinAnimation;
    }

    private void OnDisable()
    {
        _win.OnWin -= StartWinAnimation;
    }

    private void OnTriggerEnter(Collider other)
    {
        ActivateTileOnCollision();
    }

    private void ActivateTileOnCollision()
    {
        StartAnimation();
        _renderer.enabled = true;
    }

    public void StartAnimation()
    {
        
        Sequence sequence = DOTween.Sequence();
        
        if (sequence.IsComplete()) return;
        
        if(!_renderer.enabled)
        {
            transform.DOScale(_maxScale, _animDuration);
            _win.AddActiveTileCount();
            _win.CheckWinCondition();
        }
        else
        {
            sequence.Append(transform.DOScale(_minScale, _animDuration))
                    .Append(transform.DOScale(_maxScale, _animDuration));
        }
    }

    private void StartWinAnimation()
    {
        _renderer.enabled = true;
        transform.DOScale(_maxScale, _animDuration * 2);
    }

}

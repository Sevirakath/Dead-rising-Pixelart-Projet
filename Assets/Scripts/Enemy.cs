using UnityEngine;

public class Enemy : MonoBehaviour, IEffectable
{
    private float _maxHealth = 100f;
    [SerializeField] private float currentHealth;
    
    private StatusEffectData _data;

    private float _moveSpeed = 2f;
    private float _currentMoveSpeed;

    private Vector3 startPos;
    public bool shouldMove = false;

    private void Start()
    {
        startPos = transform.position;
        _currentMoveSpeed = _moveSpeed;
        currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (_data != null) HandleEffect();
        
        if (shouldMove) HandleMove();
    }

    public bool moveRight = true;
    void HandleMove()
    {
        if (moveRight && Vector3.Distance(transform.position, startPos + (transform.right * 3f)) < 0.01)
        {
            moveRight = false;
        }

        if (!moveRight && Vector3.Distance(transform.position, startPos + (-transform.right * 3f)) < 0.01)
        {
            moveRight = true;
        }
        
        if (moveRight) transform.position += transform.right * _currentMoveSpeed * Time.deltaTime;
        else transform.position += -transform.right * _currentMoveSpeed * Time.deltaTime;
    }

    private GameObject _effectParticles;
    public void ApplyEffect(StatusEffectData _data)
    {
        RemoveEffect();
        this._data = _data;
        if (_data.MovementPenalty > 0) _currentMoveSpeed = _moveSpeed / _data.MovementPenalty;
        _effectParticles = Instantiate(_data.EffectParticles, transform);
    }

    private float _currentEffectTime = 0f;
    private float _nextTickTime = 0f;
    public void RemoveEffect() 
    {
        _data = null;
        _currentEffectTime = 0;
        _nextTickTime = 0;
        _currentMoveSpeed = _moveSpeed;
        if (_effectParticles != null) Destroy(_effectParticles);
    }

    
    public void HandleEffect()
    {
        _currentEffectTime += Time.deltaTime;
        
        if (_currentEffectTime >= _data.Lifetime) RemoveEffect();

        if (_data == null) return;
        
        if (_data.DOTAmount != 0 && _currentEffectTime > _nextTickTime)
        {
            _nextTickTime += _data.TickSpeed;
            currentHealth -= _data.DOTAmount;

            currentHealth = Mathf.Clamp(currentHealth, 0, _maxHealth);
        }
    }
}

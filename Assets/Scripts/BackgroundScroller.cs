using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed;
    
    private Renderer _renderer;
    private const string TextureName = "_MainTex";

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        var x = Mathf.Repeat(Time.time * _scrollSpeed, 1);
        var offset = new Vector2(x, 0);
        _renderer.sharedMaterial.SetTextureOffset(TextureName, offset);
    }
}
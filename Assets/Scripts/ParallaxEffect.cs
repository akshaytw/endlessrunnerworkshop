using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Renderer road;
    [SerializeField] private float parallaxSpeed;
    private float scrollAmount;
    private Material roadMaterial;

    private void Start()
    {
        roadMaterial = road.material;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (scrollAmount > 10)
            scrollAmount = 0;
        scrollAmount += parallaxSpeed;
        roadMaterial.mainTextureOffset = new Vector2(roadMaterial.mainTextureOffset.x, scrollAmount);
    }
}

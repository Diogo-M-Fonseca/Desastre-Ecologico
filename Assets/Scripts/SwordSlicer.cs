using UnityEngine;
using EzySlice;


public class SwordSlicer : MonoBehaviour
{
    [SerializeField] private Transform bladeBase;
    [SerializeField] private Transform bladeTip;
    [SerializeField] private LayerMask sliceableLayer;
    [SerializeField] private Material crossSectionMaterial;
    [SerializeField] private float minSwingSpeed = 1.5f;
    [SerializeField] private float separationForce = 2f;

    private Vector3 lastTipPos;
    private Vector3 tipVelocity;

    void Start() => lastTipPos = bladeTip.position;

    void FixedUpdate()
    {
        tipVelocity = (bladeTip.position - lastTipPos) / Time.fixedDeltaTime;
        lastTipPos = bladeTip.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & sliceableLayer) == 0) return;
        if (tipVelocity.magnitude < minSwingSpeed) return; // ignore slow bumps

        TrySlice(other.gameObject);
    }

    void TrySlice(GameObject target)
    {
        Vector3 bladeAxis = (bladeTip.position - bladeBase.position).normalized;
        Vector3 planeNormal = Vector3.Cross(bladeAxis, tipVelocity.normalized).normalized;
        Vector3 planePoint = (bladeBase.position + bladeTip.position) * 0.5f;

        SlicedHull hull = target.Slice(planePoint, planeNormal, crossSectionMaterial);
        if (hull == null) return;

        GameObject upper = hull.CreateUpperHull(target, crossSectionMaterial);
        GameObject lower = hull.CreateLowerHull(target, crossSectionMaterial);

        SetupPiece(upper, target, planeNormal);
        SetupPiece(lower, target, -planeNormal);

        Destroy(target);
    }

    void SetupPiece(GameObject piece, GameObject original, Vector3 pushDir)
    {
        if (piece == null) return;

        // Preserva o parent do original, mantendo a posição/rotação no mundo
        piece.transform.SetParent(original.transform.parent, true);
        piece.transform.position = original.transform.position;
        piece.transform.rotation = original.transform.rotation;
        piece.transform.localScale = original.transform.lossyScale;

        piece.layer = original.layer;

        var col = piece.AddComponent<MeshCollider>();
        col.convex = true;

        var rb = piece.AddComponent<Rigidbody>();
        rb.AddForce(pushDir * separationForce, ForceMode.Impulse);
    }
}
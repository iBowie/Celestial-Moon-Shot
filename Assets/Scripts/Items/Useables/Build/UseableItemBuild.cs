using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Items.Useables.Build
{
    public class UseableItemBuild : UseableItemBase
    {
        public GameObject previewPrefab;
        public GameObject buildPrefab;
        public bool allowBuildInAir;

        private GameObject currentPreview;
        private SpriteRenderer currentPreviewRenderer;
        private Collider2D currentPreviewCollider;
        private Transform currentPreviewGround;

        private LayerMask blockMask;
        private LayerMask snapMask;
        private ContactFilter2D contactFilter;
        private float offsetY;

        public UseableItemBuild()
        {
            reachDistance = 10f;
        }

        protected override void PostAwake()
        {
            blockMask = LayerMask.GetMask("Item", "Enemy", "Player", "Ground", "Build");
            snapMask = LayerMask.GetMask("Ground", "Build");

            currentPreview = GameObject.Instantiate(previewPrefab);
            currentPreviewRenderer = currentPreview.GetComponent<SpriteRenderer>();
            currentPreviewCollider = currentPreview.GetComponent<Collider2D>();
            currentPreviewGround = currentPreview.transform.Find("Ground");

            contactFilter = new ContactFilter2D() { useLayerMask = true, layerMask = blockMask };

            offsetY = currentPreviewGround.transform.position.y;
        }

        private void OnDestroy()
        {
            GameObject.Destroy(currentPreview);
        }

        private bool isPossible = false;

        private void FixedUpdate()
        {
            var target = controller.target;

            var targetPos = target.transform.position;
            var targetRot = target.transform.rotation;

            bool isInAir;

            var cast = Physics2D.Raycast(targetPos, -target.transform.up, 8f, snapMask);
            if (cast.transform != null)
            {
                Vector3 dir = targetPos - (Vector3)cast.point;

                var normalized = dir.normalized;

                normalized *= cast.distance + offsetY;

                currentPreview.transform.position = targetPos - normalized;

                isInAir = false;
            }
            else
            {
                currentPreview.transform.position = targetPos;
                
                isInAir = true;
            }

            currentPreview.transform.rotation = targetRot;

            List<Collider2D> results = new List<Collider2D>();
            Physics2D.OverlapCollider(currentPreviewCollider, contactFilter, results);

            isPossible = (results.Count == 0) && ((allowBuildInAir && isInAir) || (!isInAir));

            if (isPossible)
            {
                currentPreviewRenderer.color = new Color(0f, 1f, 0f);
            }
            else
            {
                currentPreviewRenderer.color = new Color(1f, 0f, 0f);
            }
        }

        public override void OnLeftButtonDown()
        {
            if (isPossible)
            {
                var build = GameObject.Instantiate(buildPrefab);

                build.transform.position = currentPreview.transform.position;
                build.transform.rotation = currentPreview.transform.rotation;

                GameObject.Destroy(currentPreview);

                Consume();
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Items.Useables.Build
{
    public class UseableItemBuild : UseableItemBase
    {
        public GameObject previewPrefab;
        public GameObject buildPrefab;

        private GameObject currentPreview;
        private SpriteRenderer currentPreviewRenderer;
        private Collider2D currentPreviewCollider;

        private LayerMask blockMask;

        public UseableItemBuild()
        {
            reachDistance = 10f;
        }

        protected override void PostAwake()
        {
            blockMask = LayerMask.GetMask("Item", "Enemy", "Player", "Ground", "Build");

            currentPreview = GameObject.Instantiate(previewPrefab);
            currentPreviewRenderer = currentPreview.GetComponent<SpriteRenderer>();
            currentPreviewCollider = currentPreview.GetComponent<Collider2D>();
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

            currentPreview.transform.position = targetPos;
            currentPreview.transform.rotation = targetRot;

            List<Collider2D> results = new List<Collider2D>();
            Physics2D.OverlapCollider(currentPreviewCollider, new ContactFilter2D() { useLayerMask = true, layerMask = blockMask }, results);

            isPossible = results.Count == 0;

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

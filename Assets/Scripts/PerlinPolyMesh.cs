using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class PerlinPolyMesh : MonoBehaviour
{
    private PolygonCollider2D poly2d;
    private MeshFilter mf;

    [Range(0f, 100f)]
    public float minRadius;
    [Range(0.01f, 100f)]
    public float maxScale;
    [Range(0.01f, 100f)]
    public float minScale;
    public int count;
    public bool generateNow;
    // Start is called before the first frame update
    void Start()
    {
        poly2d = GetComponent<PolygonCollider2D>();
        mf = GetComponent<MeshFilter>();

        Generate();
    }

    private float oldRadius, oldCount, oldMinScale, oldMaxScale;
    private bool oldGenerateNow;
    private void Update()
    {
        if (Application.isEditor)
        {
            if (generateNow != oldGenerateNow || minRadius != oldRadius || count != oldCount || minScale != oldMinScale || maxScale != oldMaxScale)
            {
                Generate();
            }
            oldRadius = minRadius;
            oldCount = count;
            oldMinScale = minScale;
            oldMaxScale = maxScale;
            oldGenerateNow = generateNow;
        }
    }

    void Generate()
    {
        List<Vector3> verticies = new List<Vector3>();
        float x, y;
        int i = 0;

        for (i = 0; i < count; i++)
        {
            float radius = minRadius + Mathf.PerlinNoise((float)i / count, (float)i / count) * Random.Range(minScale, maxScale);

            x = Mathf.Sin((2 * Mathf.PI * i) / count);
            y = Mathf.Cos((2 * Mathf.PI * i) / count);
            verticies.Add(new Vector3(x, y, 0f) * radius);
        }

        List<int> triangles = new List<int> { };

        for (i = 0; i < (count - 2); i++)
        {
            triangles.Add(0);
            triangles.Add(i + 1);
            triangles.Add(i + 2);
        }

        List<Vector3> normals = new List<Vector3> { };
        for (i = 0; i < verticies.Count; i++)
        {
            normals.Add(-Vector3.forward);
        }

        var mesh = new Mesh();
        mf.mesh = mesh;

        mesh.vertices = verticies.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.normals = normals.ToArray();

        poly2d.pathCount = 1;

        List<Vector2> pathList = new List<Vector2>();

        for (i = 0; i < count; i++)
        {
            pathList.Add(new Vector2(verticies[i].x, verticies[i].y));
        }
        Vector2[] path = pathList.ToArray();

        poly2d.SetPath(0, path);
    }
}

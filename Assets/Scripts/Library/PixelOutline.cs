using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ruccho.Utilities
{
    public class PixelOutline : Shadow
    {
        [SerializeField]
        public bool EightDirection;
        protected PixelOutline()
        { }

        public override void ModifyMesh(VertexHelper vh)
        {
            if (!IsActive())
                return;

            var verts = new List<UIVertex>();
            vh.GetUIVertexStream(verts);

            var neededCpacity = verts.Count * 5;
            if (verts.Capacity < neededCpacity)
                verts.Capacity = neededCpacity;

            var start = 0;
            var end = verts.Count;
            ApplyShadowZeroAlloc(verts, effectColor, start, verts.Count, effectDistance.x, 0);
            ApplyShadowZeroAlloc(verts, effectColor, start, verts.Count, effectDistance.x*2, 0);

            start = end;
            end = verts.Count;
            ApplyShadowZeroAlloc(verts, effectColor, start, verts.Count, -effectDistance.x, 0);
            ApplyShadowZeroAlloc(verts, effectColor, start, verts.Count, -effectDistance.x*2, 0);

            start = end;
            end = verts.Count;
            ApplyShadowZeroAlloc(verts, effectColor, start, verts.Count, 0, effectDistance.y);
            ApplyShadowZeroAlloc(verts, effectColor, start, verts.Count, 0, effectDistance.y*2);

            start = end;
            end = verts.Count;
            ApplyShadowZeroAlloc(verts, effectColor, start, verts.Count, 0, -effectDistance.y);
            ApplyShadowZeroAlloc(verts, effectColor, start, verts.Count, 0, -effectDistance.y*2);

            if (EightDirection)
            {
                start = end;
                end = verts.Count;
                ApplyShadowZeroAlloc(verts, effectColor, start, verts.Count, effectDistance.x, effectDistance.y);

                start = end;
                end = verts.Count;
                ApplyShadowZeroAlloc(verts, effectColor, start, verts.Count, effectDistance.x, -effectDistance.y);

                start = end;
                end = verts.Count;
                ApplyShadowZeroAlloc(verts, effectColor, start, verts.Count, -effectDistance.x, effectDistance.y);

                start = end;
                end = verts.Count;
                ApplyShadowZeroAlloc(verts, effectColor, start, verts.Count, -effectDistance.x, -effectDistance.y);
            }

            vh.Clear();
            vh.AddUIVertexTriangleStream(verts);

        }
    }
}

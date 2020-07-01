﻿using System;
using System.Collections.Generic;
using System.Linq;
using Iviz.Resources;
using UnityEngine;

namespace Iviz.Displays
{
    public class MeshMarkerResource : MarkerResource, ISupportsAROcclusion, ISupportsTint
    {
        protected MeshRenderer MainRenderer { get; private set; }

        Material textureMaterial;
        Material textureMaterialAlpha;

        [SerializeField] Texture2D texture;
        public Texture2D Texture
        {
            get => texture;
            set
            {
                if (texture == value)
                {
                    return;
                }
                textureMaterial = null;
                textureMaterialAlpha = null;
                texture = value;
                SetEffectiveColor();
            }
        }

        [SerializeField] Color color = Color.white;
        public Color Color
        {
            get => color;
            set
            {
                color = value;
                SetEffectiveColor();
            }
        }

        [SerializeField] bool occlusionOnly;
        public bool OcclusionOnly
        {
            get => occlusionOnly;
            set
            {
                occlusionOnly = value;
                if (value)
                {
                    MainRenderer.sharedMaterial = Resource.Materials.LitOcclusionOnly.Object;
                }
                else
                {
                    SetEffectiveColor();
                }
            }
        }

        [SerializeField] Color tint = Color.white;
        public Color Tint
        {
            get => tint;
            set
            {
                tint = value;
                SetEffectiveColor();
            }
        }

        Color EffectiveColor => Color * Tint;

        void SetEffectiveColor()
        {
            if (OcclusionOnly)
            {
                return;
            }
            Color effectiveColor = EffectiveColor;
            if (Texture is null)
            {
                Material material = effectiveColor.a > 254f / 255f ?
                    Resource.Materials.Lit.Object :
                    Resource.Materials.TransparentLit.Object;
                MainRenderer.sharedMaterial = material;
            }
            else if (effectiveColor.a > 254f / 255f)
            {
                if (textureMaterial is null)
                {
                    textureMaterial = Resource.TexturedMaterials.Get(Texture);
                }
                MainRenderer.material = textureMaterial;
            }
            else
            {
                if (textureMaterialAlpha is null)
                {
                    textureMaterialAlpha = Resource.TexturedMaterials.GetAlpha(Texture);
                }
                MainRenderer.sharedMaterial = textureMaterial;
            }
            MainRenderer.SetPropertyColor(effectiveColor);
        }

        protected override void Awake()
        {
            base.Awake();
            MainRenderer = GetComponent<MeshRenderer>();
            Color = color;
        }

        public override void Stop()
        {
            base.Stop();
            Color = Color.white;
            ColliderEnabled = true;
            OcclusionOnly = false;
        }
    }
}
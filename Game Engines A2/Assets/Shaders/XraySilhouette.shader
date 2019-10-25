// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'



Shader "Custom/XraySilhouette"
{
    Properties
    {
        _Colour ("Main Colour", Color) = (0,0,0,1)
        _OutlineColour ("Outline Colour", Color) = (0,0,0,1)
        _Outline ("Outline Width", Range(0.0,1.0)) = 0.005
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }

    CGINCLUDE
    #include "UnityCG.cginc"

    struct appdata 
    {
        float4 vertex : POSITION;
        float3 normal : NORMAL;
    };
    struct v2f
    {
        float4 pos : POSITION;
        float4 colour : COLOR;
    };
    uniform float _Outline;
    uniform float4 _OutlineColour; 
    uniform float4 _Colour;

    //-----Copy of vertex data scaled according to normals-----
    v2f vert (appdata v)
    {
        v2f output;
        output.pos = UnityObjectToClipPos(v.vertex);

        float3 norm = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
        float2 offset = TransformViewToProjection(norm.xy);

        output.pos.xy += offset * output.pos.z * _Outline;
        output.colour = _OutlineColour;
        return output;
    }
    ENDCG

    //-----------------//
    SubShader
    {
        Tags { "Queue" = "Transparent" }

        Pass 
        {
            Name "OUTLINE"
            Tags {"LightMode" = "Always"}
            Cull Off
            ZWrite Off
            ZTest Always
            ColorMask RGB

            //-----Different Blend Modes-----
            Blend SrcAlpha OneMinusSrcAlpha // Normal
		    //Blend One One                 // Additive
		    //Blend One OneMinusDstColor    // Soft Additive
		    //Blend DstColor Zero           // Multiplicative
		    //Blend DstColor SrcColor       // 2x Multiplicative

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            half4 frag(v2f i) :COLOR
            {
                return i.colour;
            }
            ENDCG
        }

        Pass
        {
            Name "BASE"
            ZWrite On
            ZTest LEqual
            //Blend SrcAlpha OneMinusSrcAlpha
            Material 
            {  
                Diffuse[_Colour]
                Ambient[_Colour]
            }
            Lighting On
            SetTexture[_MainTex]
            {
                ConstantColor[_Colour]
                Combine texture * constant
            }
            SetTexture[_MainTex]
            {
                Combine previous * primary DOUBLE
            }
        }
    }

    //-----------------//
    SubShader
    {
        Tags { "Queue"="Transparent" }
  
        Pass 
        {
            Name "OUTLINE"
            Tags {"LightMode" = "Always"}
            Cull Front
            ZWrite Off
            ZTest Always
            ColorMask RGB

            //-----Different Blend Modes-----
            Blend SrcAlpha OneMinusSrcAlpha // Normal
		    //Blend One One                 // Additive
		    //Blend One OneMinusDstColor    // Soft Additive
		    //Blend DstColor Zero           // Multiplicative
		    //Blend DstColor SrcColor       // 2x Multiplicative

            //CGPROGRAM
            //#pragma vertex vert
            //#pragma exclude_renderers gles xbox360 ps3
            //ENDCG
            SetTexture[_MainTex] {combine primary}
        }

        Pass
        {
            Name "BASE"
            ZWrite On
            ZTest LEqual
            //Blend SrcAlpha OneMinusSrcAlpha
            Material 
            {  
                Diffuse[_Colour]
                Ambient[_Colour]
            }
            Lighting On
            SetTexture[_MainTex]
            {
                ConstantColor[_Colour]
                Combine texture * constant
            }
            SetTexture[_MainTex]
            {
                Combine previous * primary DOUBLE
            }
        }
    }
    FallBack "Diffuse"
}

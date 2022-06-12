Shader "Hidden/LightweightPipeline/CopyDepth" {
	Properties {
	}
	SubShader {
		Tags { "RenderPipeline" = "LightweightPipeline" "RenderType" = "Opaque" }
		Pass {
			Name "Default"
			Tags { "RenderPipeline" = "LightweightPipeline" "RenderType" = "Opaque" }
			ColorMask 0 -1
			ZTest Always
			GpuProgramID 4809
			Program "vp" {
				SubProgram "d3d11 " {
					Keywords { "_DEPTH_NO_MSAA" }
					"!!vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[21];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[19];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[3];
					};
					in  vec4 in_POSITION0;
					in  vec2 in_TEXCOORD0;
					out vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * unity_ObjectToWorld[1];
					    u_xlat0 = unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * unity_MatrixVP[1];
					    u_xlat1 = unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}"
				}
				SubProgram "d3d11 " {
					Keywords { "_DEPTH_MSAA_2" }
					"!!vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[21];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[19];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[3];
					};
					in  vec4 in_POSITION0;
					in  vec2 in_TEXCOORD0;
					out vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * unity_ObjectToWorld[1];
					    u_xlat0 = unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * unity_MatrixVP[1];
					    u_xlat1 = unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}"
				}
				SubProgram "d3d11 " {
					Keywords { "_DEPTH_MSAA_4" }
					"!!vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[21];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[19];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[3];
					};
					in  vec4 in_POSITION0;
					in  vec2 in_TEXCOORD0;
					out vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * unity_ObjectToWorld[1];
					    u_xlat0 = unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * unity_MatrixVP[1];
					    u_xlat1 = unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}"
				}
			}
			Program "fp" {
				SubProgram "d3d11 " {
					Keywords { "_DEPTH_NO_MSAA" }
					"!!ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					uniform  sampler2D _CameraDepthAttachment;
					in  vec2 vs_TEXCOORD0;
					vec4 u_xlat10_0;
					void main()
					{
					    u_xlat10_0 = texture(_CameraDepthAttachment, vs_TEXCOORD0.xy);
					    gl_FragDepth = u_xlat10_0.x;
					    return;
					}"
				}
				SubProgram "d3d11 " {
					Keywords { "_DEPTH_MSAA_2" }
					"!!ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform PGlobals {
						vec4 _CameraDepthAttachment_TexelSize;
					};
					uniform  sampler2DMS _CameraDepthAttachment;
					in  vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					uvec4 u_xlatu0;
					vec4 u_xlat1;
					float u_xlat2;
					void main()
					{
					    u_xlat0.xy = vs_TEXCOORD0.xy * _CameraDepthAttachment_TexelSize.zw;
					    u_xlatu0.xy = uvec2(ivec2(u_xlat0.xy));
					    u_xlatu0.z = uint(0u);
					    u_xlatu0.w = uint(0u);
					    u_xlat1 = texelFetch(_CameraDepthAttachment, ivec2(u_xlatu0.xy), int(u_xlatu0.w));
					    u_xlat0 = texelFetch(_CameraDepthAttachment, ivec2(u_xlatu0.xy), int(u_xlatu0.w));
					    u_xlat2 = min(u_xlat1.x, 1.0);
					    gl_FragDepth = min(u_xlat2, u_xlat0.x);
					    return;
					}"
				}
				SubProgram "d3d11 " {
					Keywords { "_DEPTH_MSAA_4" }
					"!!ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform PGlobals {
						vec4 _CameraDepthAttachment_TexelSize;
					};
					uniform  sampler2DMS _CameraDepthAttachment;
					in  vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					uvec4 u_xlatu0;
					vec4 u_xlat1;
					vec4 u_xlat2;
					float u_xlat3;
					void main()
					{
					    u_xlat0.xy = vs_TEXCOORD0.xy * _CameraDepthAttachment_TexelSize.zw;
					    u_xlatu0.xy = uvec2(ivec2(u_xlat0.xy));
					    u_xlatu0.z = uint(0u);
					    u_xlatu0.w = uint(0u);
					    u_xlat1 = texelFetch(_CameraDepthAttachment, ivec2(u_xlatu0.xy), int(u_xlatu0.w));
					    u_xlat1.x = min(u_xlat1.x, 1.0);
					    u_xlat2 = texelFetch(_CameraDepthAttachment, ivec2(u_xlatu0.xy), int(u_xlatu0.w));
					    u_xlat1.x = min(u_xlat1.x, u_xlat2.x);
					    u_xlat2 = texelFetch(_CameraDepthAttachment, ivec2(u_xlatu0.xy), int(u_xlatu0.w));
					    u_xlat0 = texelFetch(_CameraDepthAttachment, ivec2(u_xlatu0.xy), int(u_xlatu0.w));
					    u_xlat3 = min(u_xlat1.x, u_xlat2.x);
					    gl_FragDepth = min(u_xlat3, u_xlat0.x);
					    return;
					}"
				}
			}
		}
	}
}
using System.Drawing;
using System;
using System.Runtime.InteropServices;
#if OSX
using MonoMac.OpenGL;
#else
using OpenTK;
#endif

namespace MonkVG
{
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public partial class VG  
	{

		public enum ParamTypeMnk
		{
			TESSELLATION_ITERATIONS_MNK              = 0x1170,
			SURFACE_WIDTH_MNK                        = 0x1171,
			SURFACE_HEIGHT_MNK                       = 0x1172
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum RenderingBackendTypeMNK
		{
			OPENGLES11                               = 0,
			OPENGLES20                               = 1
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum Version
		{
			VG_10                                    = 1,
			VG_101                                   = 1,
			VG_11                                    = 2
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum Boolean
		{
			TRUE                                     = 1,
			FALSE                                    = 0
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum Error
		{
			NO_ERROR =0,
			BAD_HANDLE_ERROR                         = 0x1000,
			ILLEGAL_ARGUMENT_ERROR                   = 0x1001,
			OUT_OF_MEMORY_ERROR                      = 0x1002,
			PATH_CAPABILITY_ERROR                    = 0x1003,
			UNSUPPORTED_IMAGE_FORMAT_ERROR           = 0x1004,
			UNSUPPORTED_PATH_FORMAT_ERROR            = 0x1005,
			IMAGE_IN_USE_ERROR                       = 0x1006,
			NO_CONTEXT_ERROR                         = 0x1007
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum ParamType : uint
		{
			/* Mode settings */
			MATRIX_MODE                              = 0x1100,
			FILL_RULE                                = 0x1101,
			IMAGE_QUALITY                            = 0x1102,
			RENDERING_QUALITY                        = 0x1103,
			BLEND_MODE                               = 0x1104,
			IMAGE_MODE                               = 0x1105,

			/* Scissoring rectangles */
			SCISSOR_RECTS                            = 0x1106,

			/* Color Transformation */
			COLOR_TRANSFORM                          = 0x1170,
			COLOR_TRANSFORM_VALUES                   = 0x1171,

			/* Stroke parameters */
			STROKE_LINE_WIDTH                        = 0x1110,
			STROKE_CAP_STYLE                         = 0x1111,
			STROKE_JOIN_STYLE                        = 0x1112,
			STROKE_MITER_LIMIT                       = 0x1113,
			STROKE_DASH_PATTERN                      = 0x1114,
			STROKE_DASH_PHASE                        = 0x1115,
			STROKE_DASH_PHASE_RESET                  = 0x1116,

			/* Edge fill color for VG_TILE_FILL tiling mode */
			TILE_FILL_COLOR                          = 0x1120,

			/* Color for vgClear */
			CLEAR_COLOR                              = 0x1121,

			/* Glyph origin */
			GLYPH_ORIGIN                             = 0x1122,

			/* Enable/disable alpha masking and scissoring */
			MASKING                                  = 0x1130,
			SCISSORING                               = 0x1131,

			/* Pixel layout information */
			PIXEL_LAYOUT                             = 0x1140,
			SCREEN_LAYOUT                            = 0x1141,

			/* Source format selection for image filters */
			FILTER_FORMAT_LINEAR                     = 0x1150,
			FILTER_FORMAT_PREMULTIPLIED              = 0x1151,

			/* Destination write enable mask for image filters */
			FILTER_CHANNEL_MASK                      = 0x1152,

			/* Implementation limits (read-only) */
			MAX_SCISSOR_RECTS                        = 0x1160,
			MAX_DASH_COUNT                           = 0x1161,
			MAX_KERNEL_SIZE                          = 0x1162,
			MAX_SEPARABLE_KERNEL_SIZE                = 0x1163,
			MAX_COLOR_RAMP_STOPS                     = 0x1164,
			MAX_IMAGE_WIDTH                          = 0x1165,
			MAX_IMAGE_HEIGHT                         = 0x1166,
			MAX_IMAGE_PIXELS                         = 0x1167,
			MAX_IMAGE_BYTES                          = 0x1168,
			MAX_FLOAT                                = 0x1169,
			MAX_GAUSSIAN_STD_DEVIATION               = 0x116A
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum RenderingQuality
		{
			NONANTIALIASED                           = 0x1200,
			FASTER                                   = 0x1201,
			BETTER                                   = 0x1202, /* Default */
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum PixelLayout
		{
			UNKNOWN                                  = 0x1300,
			RGB_VERTICAL                             = 0x1301,
			BGR_VERTICAL                             = 0x1302,
			RGB_HORIZONTAL                           = 0x1303,
			BGR_HORIZONTAL                           = 0x1304
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum MatrixMode
		{
			PATH_USER_TO_SURFACE                     = 0x1400,
			IMAGE_USER_TO_SURFACE                    = 0x1401,
			FILL_PAINT_TO_USER                       = 0x1402,
			STROKE_PAINT_TO_USER                     = 0x1403,
			GLYPH_USER_TO_SURFACE                    = 0x1404
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum MaskOperation
		{
			CLEAR_MASK                               = 0x1500,
			FILL_MASK                                = 0x1501,
			SET_MASK                                 = 0x1502,
			UNION_MASK                               = 0x1503,
			INTERSECT_MASK                           = 0x1504,
			SUBTRACT_MASK                            = 0x1505
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum PathFormat : int
		{
			STANDARD 								 = 0
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum PathDataType
		{
			S_8                                      =  0,
			S_16                                     =  1,
			S_32                                     =  2,
			F                                        =  3
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum PathAbsRel : byte
		{
			ABSOLUTE                                 = 0,
			RELATIVE                                 = 1
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum PathSegment : byte
		{
			CLOSE_PATH                               = ( 0 << 1),
			MOVE_TO                                  = ( 1 << 1),
			LINE_TO                                  = ( 2 << 1),
			HLINE_TO                                 = ( 3 << 1),
			VLINE_TO                                 = ( 4 << 1),
			QUAD_TO                                  = ( 5 << 1),
			CUBIC_TO                                 = ( 6 << 1),
			SQUAD_TO                                 = ( 7 << 1),
			SCUBIC_TO                                = ( 8 << 1),
			SCCWARC_TO                               = ( 9 << 1),
			SCWARC_TO                                = (10 << 1),
			LCCWARC_TO                               = (11 << 1),
			LCWARC_TO                                = (12 << 1)
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum PathCommand : byte
		{
			MOVE_TO_ABS                              = PathSegment.MOVE_TO    | PathAbsRel.ABSOLUTE,
			MOVE_TO_REL                              = PathSegment.MOVE_TO    | PathAbsRel.RELATIVE,
			LINE_TO_ABS                              = PathSegment.LINE_TO    | PathAbsRel.ABSOLUTE,
			LINE_TO_REL                              = PathSegment.LINE_TO    | PathAbsRel.RELATIVE,
			HLINE_TO_ABS                             = PathSegment.HLINE_TO   | PathAbsRel.ABSOLUTE,
			HLINE_TO_REL                             = PathSegment.HLINE_TO   | PathAbsRel.RELATIVE,
			VLINE_TO_ABS                             = PathSegment.VLINE_TO   | PathAbsRel.ABSOLUTE,
			VLINE_TO_REL                             = PathSegment.VLINE_TO   | PathAbsRel.RELATIVE,
			QUAD_TO_ABS                              = PathSegment.QUAD_TO    | PathAbsRel.ABSOLUTE,
			QUAD_TO_REL                              = PathSegment.QUAD_TO    | PathAbsRel.RELATIVE,
			CUBIC_TO_ABS                             = PathSegment.CUBIC_TO   | PathAbsRel.ABSOLUTE,
			CUBIC_TO_REL                             = PathSegment.CUBIC_TO   | PathAbsRel.RELATIVE,
			SQUAD_TO_ABS                             = PathSegment.SQUAD_TO   | PathAbsRel.ABSOLUTE,
			SQUAD_TO_REL                             = PathSegment.SQUAD_TO   | PathAbsRel.RELATIVE,
			SCUBIC_TO_ABS                            = PathSegment.SCUBIC_TO  | PathAbsRel.ABSOLUTE,
			SCUBIC_TO_REL                            = PathSegment.SCUBIC_TO  | PathAbsRel.RELATIVE,
			SCCWARC_TO_ABS                           = PathSegment.SCCWARC_TO | PathAbsRel.ABSOLUTE,
			SCCWARC_TO_REL                           = PathSegment.SCCWARC_TO | PathAbsRel.RELATIVE,
			SCWARC_TO_ABS                            = PathSegment.SCWARC_TO  | PathAbsRel.ABSOLUTE,
			SCWARC_TO_REL                            = PathSegment.SCWARC_TO  | PathAbsRel.RELATIVE,
			LCCWARC_TO_ABS                           = PathSegment.LCCWARC_TO | PathAbsRel.ABSOLUTE,
			LCCWARC_TO_REL                           = PathSegment.LCCWARC_TO | PathAbsRel.RELATIVE,
			LCWARC_TO_ABS                            = PathSegment.LCWARC_TO  | PathAbsRel.ABSOLUTE,
			LCWARC_TO_REL                            = PathSegment.LCWARC_TO  | PathAbsRel.RELATIVE
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum PathCapabilities
		{
			APPEND_FROM                              = (1 <<  0),
			APPEND_TO                                = (1 <<  1),
			MODIFY                                   = (1 <<  2),
			TRANSFORM_FROM                           = (1 <<  3),
			TRANSFORM_TO                             = (1 <<  4),
			INTERPOLATE_FROM                         = (1 <<  5),
			INTERPOLATE_TO                           = (1 <<  6),
			PATH_LENGTH                              = (1 <<  7),
			POINT_ALONG_PATH                         = (1 <<  8),
			TANGENT_ALONG_PATH                       = (1 <<  9),
			PATH_BOUNDS                              = (1 << 10),
			PATH_TRANSFORMED_BOUNDS                  = (1 << 11),
			ALL                                      = (1 << 12) - 1		
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum PathParamType : uint
		{
			PATH_FORMAT                              = 0x1600,
			PATH_DATATYPE                            = 0x1601,
			PATH_SCALE                               = 0x1602,
			PATH_BIAS                                = 0x1603,
			PATH_NUM_SEGMENTS                        = 0x1604,
			PATH_NUM_COORDS                          = 0x1605
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum CapStyle
		{
			CAP_BUTT                                 = 0x1700,
			CAP_ROUND                                = 0x1701,
			CAP_SQUARE                               = 0x1702
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum JoinStyle
		{
			JOIN_MITER                               = 0x1800,
			JOIN_ROUND                               = 0x1801,
			JOIN_BEVEL                               = 0x1802
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum FillRule
		{
			EVEN_ODD                                 = 0x1900,
			NON_ZERO                                 = 0x1901
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum PaintMode
		{
			STROKE_PATH                              = (1 << 0),
			FILL_PATH                                = (1 << 1)
		}

		public enum PaintParamType : ushort
		{
			TYPE                                     = 0x1A00,
			COLOR                                    = 0x1A01,
			COLOR_RAMP_SPREAD_MODE                   = 0x1A02,
			COLOR_RAMP_PREMULTIPLIED                 = 0x1A07,
			COLOR_RAMP_STOPS                         = 0x1A03,

			/* Linear gradient paint parameters */
			LINEAR_GRADIENT                          = 0x1A04,

			/* Radial gradient paint parameters */
			RADIAL_GRADIENT                          = 0x1A05,

			/* Pattern paint parameters */
			PATTERN_TILING_MODE                      = 0x1A06,

			/* 2x3 gradient paint parameters */
			PAINT_2x3_GRADIENT                       = 0x1A08
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum PaintType : int
		{
			COLOR                                    = 0x1B00,
			LINEAR_GRADIENT                          = 0x1B01,
			RADIAL_GRADIENT                          = 0x1B02,
			PATTERN                                  = 0x1B03,

			/* 2x3 matrix gradients */
			LINEAR_2x3_GRADIENT                      = 0x1B04,
			RADIAL_2x3_GRADIENT                      = 0x1B05
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum ColorRampSpreadMode
		{
			PAD                                      = 0x1C00,
			REPEAT                                   = 0x1C01,
			REFLECT                                  = 0x1C02
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum TilingMode
		{
			FILL                                     = 0x1D00,
			PAD                                      = 0x1D01,
			REPEAT                                   = 0x1D02,
			REFLECT                                  = 0x1D03
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum ImageFormat
		{
			/* RGB{A,X} channel ordering */
			sRGBX_8888                               =  0,
			sRGBA_8888                               =  1,
			sRGBA_8888_PRE                           =  2,
			sRGB_565                                 =  3,
			sRGBA_5551                               =  4,
			sRGBA_4444                               =  5,
			sL_8                                     =  6,
			lRGBX_8888                               =  7,
			lRGBA_8888                               =  8,
			lRGBA_8888_PRE                           =  9,
			lL_8                                     = 10,
			A_8                                      = 11,
			BW_1                                     = 12,
			A_1                                      = 13,
			A_4                                      = 14,

			/* {A,X}RGB channel ordering */
			sXRGB_8888                               =  0 | (1 << 6),
			sARGB_8888                               =  1 | (1 << 6),
			sARGB_8888_PRE                           =  2 | (1 << 6),
			sARGB_1555                               =  4 | (1 << 6),
			sARGB_4444                               =  5 | (1 << 6),
			lXRGB_8888                               =  7 | (1 << 6),
			lARGB_8888                               =  8 | (1 << 6),
			lARGB_8888_PRE                           =  9 | (1 << 6),

			/* BGR{A,X} channel ordering */
			sBGRX_8888                               =  0 | (1 << 7),
			sBGRA_8888                               =  1 | (1 << 7),
			sBGRA_8888_PRE                           =  2 | (1 << 7),
			sBGR_565                                 =  3 | (1 << 7),
			sBGRA_5551                               =  4 | (1 << 7),
			sBGRA_4444                               =  5 | (1 << 7),
			lBGRX_8888                               =  7 | (1 << 7),
			lBGRA_8888                               =  8 | (1 << 7),
			lBGRA_8888_PRE                           =  9 | (1 << 7),

			/* {A,X}BGR channel ordering */
			sXBGR_8888                               =  0 | (1 << 6) | (1 << 7),
			sABGR_8888                               =  1 | (1 << 6) | (1 << 7),
			sABGR_8888_PRE                           =  2 | (1 << 6) | (1 << 7),
			sABGR_1555                               =  4 | (1 << 6) | (1 << 7),
			sABGR_4444                               =  5 | (1 << 6) | (1 << 7),
			lXBGR_8888                               =  7 | (1 << 6) | (1 << 7),
			lABGR_8888                               =  8 | (1 << 6) | (1 << 7),
			lABGR_8888_PRE                           =  9 | (1 << 6) | (1 << 7)
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum ImageQuality
		{
			NONANTIALIASED                           = (1 << 0),
			FASTER                                   = (1 << 1),
			BETTER                                   = (1 << 2)
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum ImageParamType
		{
			VG_IMAGE_FORMAT                          = 0x1E00,
			VG_IMAGE_WIDTH                           = 0x1E01,
			VG_IMAGE_HEIGHT                          = 0x1E02
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum ImageMode
		{
			NORMAL                                   = 0x1F00,
			MULTIPLY                                 = 0x1F01,
			STENCIL                                  = 0x1F02
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum ImageChannel
		{
			RED                                      = (1 << 3),
			GREEN                                    = (1 << 2),
			BLUE                                     = (1 << 1),
			ALPHA                                    = (1 << 0)
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum BlendMode
		{
			SRC                                      = 0x2000,
			SRC_OVER                                 = 0x2001,
			DST_OVER                                 = 0x2002,
			SRC_IN                                   = 0x2003,
			DST_IN                                   = 0x2004,
			MULTIPLY                                 = 0x2005,
			SCREEN                                   = 0x2006,
			DARKEN                                   = 0x2007,
			LIGHTEN                                  = 0x2008,
			ADDITIVE                                 = 0x2009
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum FontParamType
		{
			VG_FONT_NUM_GLYPHS                       = 0x2F00
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum HardwareQueryType
		{
			IMAGE_FORMAT                             = 0x2100,
			PATH_DATATYPE                            = 0x2101
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum HardwareQueryResult
		{
			ACCELERATED                              = 0x2200,
			UNACCELERATED                            = 0x2201
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum StringId
		{
			VENDOR                                   = 0x2300,
			RENDERER                                 = 0x2301,
			VERSION                                  = 0x2302,
			EXTENSIONS                               = 0x2303
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetError")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgGetError")]
#endif
		public extern static int GetError();

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgFlush")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgFlush")]
#endif
		public extern static int Flush();
	
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgFinish")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgFinish")]
#endif
		public extern static int Finish();

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetf")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgSetf")]
#endif
		public extern static int Setf(uint type, float value);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSeti")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgSeti")] 
#endif
		public extern static int Seti(uint type, int value);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetfv")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgSetfv")] 
#endif
		unsafe extern static int Setfv(uint type, int count, float *values);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetiv")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgSetiv")] 
#endif
		unsafe extern static int Setiv(uint type, int count, int *values);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static int Set(uint type, float[] values)
		{
			unsafe 
			{
				fixed(float *v=values)
				{
					return Setfv (type, values.Length, v);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static int Set(uint type, int[] values)
		{
			unsafe 
			{
				fixed(int *v=values)
				{
					return Setiv (type, values.Length, v);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetf")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgGetf")] 
#endif
		public extern static  float  Getf(uint type);

#if ANDROID
		[DllImport("libOpenVG-sharedso", EntryPoint="vgGeti")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgGeti")] 
#endif
		public extern static  int  Geti(uint type);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetVectorSize")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgGetVectorSize")] 
#endif
		public extern static  int  GetVectorSize(uint type);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetfv")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgGetfv")] 
#endif
		unsafe extern static  void  Getfv(uint type, int count, float* values);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetiv")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgGetiv")] 
#endif
		unsafe extern static  void  Getiv(uint type, int count, int* values);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void Get(uint type, float[] values)
		{
			unsafe 
			{
				fixed(float *v=values)
				{
					Getfv (type, values.Length, v);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void Get(uint type, int[] values)
		{
			unsafe 
			{
				fixed(int *v=values)
				{
					Getiv (type, values.Length, v);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetParameterf")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgSetParameterf")] 
#endif
		public extern static void  SetParameterf(uint obj, uint paramType, float value);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetParameteri")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgSetParameteri")] 
#endif
		public extern static void  SetParameteri(uint obj, uint paramType, int value);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetParameterfv")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgSetParameterfv")] 
#endif
		unsafe extern static void  SetParameterfv(uint obj, uint paramType, int count, float* values);
/*
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetParameteriv")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgSetParameteriv")] 
#endif
		unsafe extern static void  SetParameteriv(uint obj, uint paramType, int count, int* values);
*/
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void SetParameter(uint obj, uint paramType, float[] values)
		{
			unsafe 
			{
				fixed(float *v=values)
				{
					SetParameterfv (obj, paramType, values.Length, v);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
		public static void SetParameter(uint obj, uint paramType, int[] values)
		{
			unsafe 
			{
				fixed(int *v=values)
				{
					SetParameteriv (obj, paramType, values.Length, v);
				}
			}
		}
*/
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetParameterf")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgGetParameterf")] 
#endif
		public extern static float GetParameterf(uint obj, int paramType);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetParameteri")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgGetParameteri")] 
#endif
		public extern static int  GetParameteri(uint obj, int paramType);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetParameterVectorSize")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgGetParameterVectorSize")] 
#endif
		public extern static int GetParameterVectorSize(uint obj, int paramType);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetParameterfv")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgGetParameterfv")] 
#endif
		unsafe extern static void GetParameterfv(uint obj, int paramType, int count, float * values);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetParameteriv")] 
#elif IOS
		[DllImport("__Internal", EntryPoint="vgGetParameteriv")] 
#endif
		unsafe extern static void GetParameteriv(uint obj, int paramType, int count, int *values);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void GetParameter(uint obj, int paramType, float[] values)
		{
			unsafe 
			{
				fixed(float *v=values)
				{
					GetParameterfv (obj, paramType, values.Length, v);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void GetParameter(uint obj, int paramType, int[] values)
		{
			unsafe 
			{
				fixed(int *v=values)
				{
					GetParameteriv (obj, paramType, values.Length, v);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgLoadIdentity")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgLoadIdentity")]
#endif
		public extern static  void LoadIdentity();

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgLoadMatrix")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgLoadMatrix")]
#endif
		unsafe extern static  void LoadMatrix(float * m);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetMatrix")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgGetMatrix")]
#endif
		unsafe extern static  void GetMatrix(float * m);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgMultMatrix")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgMultMatrix")]
#endif
		unsafe extern static  void MultMatrix(float * m);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgTranslate")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgTranslate")]
#endif
		public extern static  void Translate(float tx, float ty);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgScale")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgScale")]
#endif
		public extern static  void Scale(float sx, float sy);
/*
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgShear")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgShear")]
#endif
		public extern static  void Shear(float shx, float shy);
*/
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgRotate")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgRotate")]
#endif
		public extern static  void Rotate(float angle);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void LoadMatrix(VG.MatrixMode mm, Matrix3 m)
		{
			unsafe 
			{
				VG.Seti((uint)VG.ParamType.MATRIX_MODE,(int)mm);
				float* v = &m.R0C0;
				LoadMatrix (v);
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void LoadMatrix(Matrix3 m)
		{
			unsafe 
			{
				float* v = &m.R0C0;
				LoadMatrix (v);
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void GetMatrix(Matrix3 m)
		{
			unsafe 
			{
				float* v = &m.R0C0;
				GetMatrix (v);
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void MultMatrix(Matrix3 m)
		{
			unsafe 
			{
				float* v = &m.R0C0;
				MultMatrix (v);
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgMask")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgMask")]
#endif
		public extern static void Mask(uint mask, MaskOperation operation, int x, int y, int width, int height);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgRenderToMask")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgRenderToMask")]
#endif
		public extern static void RenderToMask(uint path, PaintMode paintModes, MaskOperation operation);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreateMaskLayer")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgCreateMaskLayer")]
#endif
		public extern static uint CreateMaskLayer(int width, int height);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyMaskLayer")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDestroyMaskLayer")]
#endif
		public extern static void DestroyMaskLayer(uint maskLayer);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgFillMaskLayer")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgFillMaskLayer")]
#endif
		public extern static void FillMaskLayer(uint maskLayer, int x, int y, int width, int height, float value);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgCopyMask")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgCopyMask")]
#endif
		public extern static void CopyMask(uint maskLayer, int dx, int dy, int sx, int sy, int width, int height);
*/
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgClear")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgClear")]
#endif
		public extern static void Clear(int x, int y, int width, int height);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreatePath")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgCreatePath")]
#endif
		public extern static  uint CreatePath(PathFormat pathFormat, PathDataType datatype, float scale, float bias, int segmentCapacityHint, int coordCapacityHint, PathCapabilities capabilities);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgClearPath")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgClearPath")]
#endif
		public extern static  void ClearPath(uint path, PathCapabilities capabilities);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyPath")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDestroyPath")]
#endif
		public extern static  void DestroyPath(uint path);
/*
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgRemovePathCapabilities")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgRemovePathCapabilities")]
#endif
		public extern static  void RemovePathCapabilities(uint path, PathCapabilities capabilities);
*/
/*
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetPathCapabilities")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgGetPathCapabilities")]
#endif
		public extern static  PathCapabilities GetPathCapabilities(uint path);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgAppendPath")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgAppendPath")]
#endif
		public extern static  void AppendPath(uint dstPath, uint srcPath);
*/
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgAppendPathData")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgAppendPathData")]
#endif
		unsafe extern static  void AppendPathData(uint dstPath, int numSegments, byte *pathSegments, void *pathData);
/*
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgModifyPathCoords")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgModifyPathCoords")]
#endif
		unsafe extern static  void ModifyPathCoords(uint dstPath, int startIndex, int numSegments, void * pathData);
*/
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgTransformPath")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgTransformPath")]
#endif
		public extern static  void TransformPath(uint dstPath, uint srcPath);
/*
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgInterpolatePath")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgInterpolatePath")]
#endif
		public extern static  bool InterpolatePath(uint dstPath, uint startPath, uint endPath, float amount);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgPathLength")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgPathLength")]
#endif
		public extern static  float PathLength(uint path, int startSegment, int numSegments);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgPointAlongPath")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgPointAlongPath")]
#endif
		unsafe extern static  void PointAlongPath(uint path, int startSegment, int numSegments, float distance, float *x, float *y, float *tangentX, float *tangentY);
*/
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgPathBounds")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgPathBounds")]
#endif
		unsafe extern static  void PathBounds(uint path, float *minX, float *minY, float *width, float*height);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgPathTransformedBounds")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgPathTransformedBounds")]
#endif
		unsafe extern static  void PathTransformedBounds(uint path, float *minX, float *minY, float *width, float *height);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDrawPath")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDrawPath")]
#endif
		public extern static  void DrawPath(uint path, PaintMode paintModes);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void AppendPathData(uint path, byte[] segments, Vector2[] coords)
		{
			unsafe {
				fixed(byte *s=segments) {
					fixed(float *c = &coords [0].X) {
						AppendPathData (path, segments.Length, s, c);
					}
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void AppendPathData(uint path, byte[] segments, float[] coords)
		{
			unsafe {
				fixed(byte *s=segments) {
					fixed(float *c = &coords [0]) {
						AppendPathData (path, segments.Length, s, c);
					}
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/*
		public static  void ModifyPathCoords(uint dstPath, int startIndex, int numSegments, Vector2[] coords)
		{
			unsafe {
				fixed(float *c=&coords [0].X) {
					ModifyPathCoords (dstPath, startIndex, numSegments, c);
				}
			}
		}
		*/
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/*
		public static Vector4 PointAlongPath(uint path, int startSegment, int numSegments, float distance)
		{
			Vector4 v=Vector4.Zero;
			unsafe {
				PointAlongPath (path, startSegment, numSegments, distance, &v.X, &v.Y, &v.W, &v.Z);
			}
			return v;
		}
		*/
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static Vector4 PathBounds(uint path)
		{
			Vector4 v=Vector4.Zero;
			unsafe {
				PathBounds (path, &v.X, &v.Y, &v.W, &v.Z);
			}
			return v;
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static Vector4 PathTransformedBounds(uint path)
		{
			Vector4 v=Vector4.Zero;
			unsafe {
				PathTransformedBounds (path, &v.X, &v.Y, &v.W, &v.Z);
			}
			return v;
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreatePaint")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgCreatePaint")]
#endif
		public extern static  uint CreatePaint();

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyPaint")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDestroyPaint")]
#endif
		public extern static  void DestroyPaint(uint paint);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetPaint")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgSetPaint")]
#endif
		public extern static  void SetPaint(uint paint, PaintMode paintModes);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetPaint")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgGetPaint")]
#endif
		public extern static  uint GetPaint(PaintMode paintMode);
/*
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetColor")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgSetColor")]
#endif
		public extern static  void SetColor(uint paint, uint rgba);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetColor")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgGetColor")]
#endif
		public extern static  uint GetColor(uint paint);
*/
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgPaintPattern")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgPaintPattern")]
#endif
		public extern static  void PaintPattern(uint paint, uint image);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreateImage")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgCreateImage")]
#endif
		public extern static  uint CreateImage(ImageFormat format, int width, int height, ImageQuality allowedQuality);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyImage")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDestroyImage")]
#endif
		public extern static  void DestroyImage(uint image);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgClearImage")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgClearImage")]
#endif
		public extern static  void ClearImage(uint image, int x, int y, int width, int height);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgImageSubData")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgImageSubData")]
#endif
		unsafe extern static  void ImageSubData(uint image, void * data, int dataStride, ImageFormat dataFormat, int x, int y, int width, int height);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetImageSubData")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgGetImageSubData")]
#endif
		unsafe extern static  void GetImageSubData(uint image, void *data, int dataStride, ImageFormat dataFormat, int x, int y, int width, int height);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgChildImage")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgChildImage")]
#endif
		public extern static  uint ChildImage(uint imageParent, int x, int y, int width, int height);
/*
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetParent")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgGetParent")]
#endif
		public extern static  uint GetParent(uint image); 
*/
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgCopyImage")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgCopyImage")]
#endif
		public extern static  void CopyImage(uint imageDst, int dx, int dy, uint imageSrc, int sx, int sy, int width, int height, Boolean dither);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDrawImage")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDrawImage")]
#endif
		public extern static  void DrawImage(uint image);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetPixels")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgSetPixels")]
#endif
		public extern static  void SetPixels(int dx, int dy, uint imageSrc, int sx, int sy, int width, int height);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgWritePixels")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgWritePixels")]
#endif
		unsafe extern static  void WritePixels(void *data, int dataStride, ImageFormat dataFormat, int dx, int dy, int width, int height);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetPixels")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgGetPixels")]
#endif
		public extern static  void GetPixels(uint imageDst, int dx, int dy, int sx, int sy, int width, int height);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgReadPixels")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgReadPixels")]
#endif
		unsafe extern static  void ReadPixels(void *data, int dataStride, ImageFormat dataFormat, int sx, int sy, int width, int height);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgCopyPixels")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgCopyPixels")]
#endif
		public extern static  void CopyPixels(int dx, int dy, int sx, int sy, int width, int height);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static  void ImageSubData(uint image, UInt32[] data, int dataStride, ImageFormat dataFormat, int x, int y, int width, int height)
		{
			unsafe
			{
				fixed(void *d=data)
				{
					ImageSubData (image, d, dataStride, dataFormat, x, y, width, height);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static  void GetImageSubData(uint image, UInt32[] data, int dataStride, ImageFormat dataFormat, int x, int y, int width, int height)
		{
			unsafe
			{
				fixed(void *d=data)
				{
					GetImageSubData (image, d, dataStride, dataFormat, x, y, width, height);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static  void WritePixels(UInt32[] data, int dataStride, ImageFormat dataFormat, int destX, int destY, int width, int height)
		{
			unsafe
			{
				fixed(void *d=data)
				{
					WritePixels (d, dataStride, dataFormat, destX, destY, width, height);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static  void ReadPixels(UInt32[] data, int dataStride, ImageFormat dataFormat, int srcX, int srcY, int width, int height)
		{
			unsafe
			{
				fixed(void *d=data)
				{
					ReadPixels (d, dataStride, dataFormat, srcX, srcY, width, height);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreateFont")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgCreateFont")]
#endif
		public extern static uint CreateFont(int glyphCapacityHint);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyFont")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDestroyFont")]
#endif
		public extern static void DestroyFont(uint font);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetGlyphToPath")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgSetGlyphToPath")]
#endif
		unsafe extern static void SetGlyphToPath(uint font, uint glyphIndex, uint path, Boolean isHinted, float* glyphOrigin, float* escapement);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetGlyphToImage")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgSetGlyphToImage")]
#endif
		unsafe extern static void SetGlyphToImage(uint font, uint glyphIndex, uint image, float* glyphOrigin, float* escapement);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgClearGlyph")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgClearGlyph")]
#endif
		public extern static void ClearGlyph(uint font,uint glyphIndex);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDrawGlyph")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDrawGlyph")]
#endif
		public extern static void DrawGlyph(uint font, uint glyphIndex, PaintMode paintModes, Boolean allowAutoHinting);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDrawGlyphs")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDrawGlyphs")]
#endif
		unsafe extern static void DrawGlyphs(uint font, int glyphCount, uint *glyphIndices, float *adjustments_x, float *adjustments_y, PaintMode paintModes, Boolean allowAutoHinting);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		// TODO: wrap unsafe

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgColorMatrix")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgColorMatrix")]
#endif
		unsafe extern static void ColorMatrix(uint dst, uint src, float *matrix);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgConvolve")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgConvolve")]
#endif
		unsafe extern static void Convolve(uint dst, uint src, int kernelWidth, int kernelHeight, int shiftX, int shiftY, short *kernel, float scale, float bias, TilingMode tilingMode);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgSeparableConvolve")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgSeparableConvolve")]
#endif
		unsafe extern static void SeparableConvolve(uint dst, uint src, int kernelWidth, int kernelHeight, int shiftX, int shiftY, short *kernelX, short *kernelY, float scale, float bias, TilingMode tilingMode);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGaussianBlur")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgGaussianBlur")]
#endif
		public extern static void GaussianBlur(uint dst, uint src, float stdDeviationX, float stdDeviationY, TilingMode tilingMode);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgLookup")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgLookup")]
#endif
		unsafe extern static void Lookup(uint dst, uint src, byte *redLUT, byte *greenLUT, byte *blueLUT, byte *alphaLUT, Boolean outputLinear, Boolean outputPremultiplied);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgLookupSingle")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgLookupSingle")]
#endif
		unsafe extern static void LookupSingle(uint dst, uint src, uint* lookupTable, ImageChannel sourceChannel, Boolean outputLinear, Boolean outputPremultiplied);
*/
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		// TODO: wrap unsafe

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgHardwareQuery")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgHardwareQuery")]
#endif
		public extern static HardwareQueryResult HardwareQuery(HardwareQueryType key, int setting);

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetString")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgGetString")]
#endif
		unsafe extern static byte* vgGetString(StringId name);
*/
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string GetString(StringId name)
		{
			switch (name) {
			case StringId.VENDOR:
				return "MonkVG#";
			case StringId.VERSION:
				return "1.1";
			case StringId.RENDERER:
				return "OpenGL ES";
			case StringId.EXTENSIONS:
				return "None";
			}
			return "Unknown";
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreateBatchMNK")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgCreateBatchMNK")]
#endif
		public extern static uint  CreateBatchMNK();

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyBatchMNK")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDestroyBatchMNK")]
#endif
		public extern static void  DestroyBatchMNK( uint batch );

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgBeginBatchMNK")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgBeginBatchMNK")]
#endif
		public extern static void BeginBatchMNK( uint batch );

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgEndBatchMNK")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgEndBatchMNK")]
#endif
		public extern static void EndBatchMNK( uint batch );

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDrawBatchMNK")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDrawBatchMNK")]
#endif
		public extern static void DrawBatchMNK( uint batch );

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDumpBatchMNK")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDumpBatchMNK")]
#endif
		unsafe extern static void DumpBatchMNK( uint batch, void **vertices, int *size );

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreateContextMNK")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgCreateContextMNK")]
#endif
		public extern static Boolean CreateContextMNK( int width, int height, RenderingBackendTypeMNK backend );

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgResizeSurfaceMNK")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgResizeSurfaceMNK")]
#endif
		public extern static void ResizeSurfaceMNK( int width, int height );

#if ANDROID
		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyContextMNK")] 
#elif IOS
		[DllImport ("__Internal",EntryPoint="vgDestroyContextMNK")]
#endif
		public extern static void DestroyContextMNK();

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	}

	/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

}


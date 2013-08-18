using System;
using System.Drawing;
using System.Runtime.InteropServices;
using OpenTK;

namespace MonkVG
{
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

		public enum PathParamType
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

		public enum PaintParamType : int
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

		enum PaintType
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

	public class VG  
	{
		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetError")] 
		public extern static int GetError();

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[DllImport("libOpenVG-shared.so", EntryPoint="vgFlush")] 
		public extern static int Flush();
	
		[DllImport("libOpenVG-shared.so", EntryPoint="vgFinish")] 
		public extern static int Finish();

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetf")] 
		public extern static int Setf(uint type, float value);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSeti")] 
		public extern static int Seti(uint type, int value);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetfv")] 
		unsafe extern static int Setfv(uint type, int count, float *values);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetiv")] 
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

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetf")] 
		public extern static  float  Getf(uint type);

		[DllImport("libOpenVG-sharedso", EntryPoint="vgGeti")] 
		public extern static  int  Geti(uint type);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetVectorSize")] 
		public extern static  int  GetVectorSize(uint type);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetfv")] 
		unsafe extern static  void  Getfv(uint type, int count, float* values);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetiv")] 
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

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetParameterf")] 
		public extern static void  SetParameterf(uint obj, int paramType, float value);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetParameteri")] 
		public extern static void  SetParameteri(uint obj, int paramType, int value);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetParameterfv")] 
		unsafe extern static void  SetParameterfv(uint obj, int paramType, int count, float* values);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetParameteriv")] 
		unsafe extern static void  SetParameteriv(uint obj, int paramType, int count, int* values);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void SetParameter(uint obj, int paramType, float[] values)
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

		public static void SetParameter(uint obj, int paramType, int[] values)
		{
			unsafe 
			{
				fixed(int *v=values)
				{
					SetParameteriv (obj, paramType, values.Length, v);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetParameterf")] 
		public extern static float GetParameterf(uint obj, int paramType);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetParameteri")] 
		public extern static int  GetParameteri(uint obj, int paramType);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetParameterVectorSize")] 
		public extern static int GetParameterVectorSize(uint obj, int paramType);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetParameterfv")] 
		unsafe extern static void GetParameterfv(uint obj, int paramType, int count, float * values);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetParameteriv")] 
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

		[DllImport("libOpenVG-shared.so", EntryPoint="vgLoadIdentity")] 
		public extern static  void LoadIdentity();

		[DllImport("libOpenVG-shared.so", EntryPoint="vgLoadMatrix")] 
		unsafe extern static  void LoadMatrix(float * m);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetMatrix")] 
		unsafe extern static  void GetMatrix(float * m);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgMultMatrix")] 
		unsafe extern static  void MultMatrix(float * m);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgTranslate")] 
		public extern static  void Translate(float tx, float ty);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgScale")] 
		public extern static  void Scale(float sx, float sy);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgShear")] 
		public extern static  void Shear(float shx, float shy);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgRotate")] 
		public extern static  void Rotate(float angle);

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

		[DllImport("libOpenVG-shared.so", EntryPoint="vgMask")] 
		public extern static void Mask(uint mask, MaskOperation operation, int x, int y, int width, int height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgRenderToMask")] 
		public extern static void RenderToMask(uint path, PaintMode paintModes, MaskOperation operation);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreateMaskLayer")] 
		public extern static uint CreateMaskLayer(int width, int height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyMaskLayer")] 
		public extern static void DestroyMaskLayer(uint maskLayer);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgFillMaskLayer")] 
		public extern static void FillMaskLayer(uint maskLayer, int x, int y, int width, int height, float value);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgCopyMask")] 
		public extern static void CopyMask(uint maskLayer, int dx, int dy, int sx, int sy, int width, int height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgClear")] 
		public extern static void Clear(int x, int y, int width, int height);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreatePath")] 
		public extern static  uint CreatePath(PathFormat pathFormat, PathDataType datatype, float scale, float bias, int segmentCapacityHint, int coordCapacityHint, PathCapabilities capabilities);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgClearPath")] 
		public extern static  void ClearPath(uint path, PathCapabilities capabilities);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyPath")] 
		public extern static  void DestroyPath(uint path);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgRemovePathCapabilities")] 
		public extern static  void RemovePathCapabilities(uint path, PathCapabilities capabilities);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetPathCapabilities")] 
		public extern static  PathCapabilities GetPathCapabilities(uint path);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgAppendPath")] 
		public extern static  void AppendPath(uint dstPath, uint srcPath);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgAppendPathData")] 
		unsafe extern static  void AppendPathData(uint dstPath, int numSegments, byte *pathSegments, void *pathData);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgModifyPathCoords")] 
		unsafe extern static  void ModifyPathCoords(uint dstPath, int startIndex, int numSegments, void * pathData);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgTransformPath")] 
		public extern static  void TransformPath(uint dstPath, uint srcPath);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgInterpolatePath")] 
		public extern static  bool InterpolatePath(uint dstPath, uint startPath, uint endPath, float amount);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgPathLength")] 
		public extern static  float PathLength(uint path, int startSegment, int numSegments);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgPointAlongPath")] 
		unsafe extern static  void PointAlongPath(uint path, int startSegment, int numSegments, float distance, float *x, float *y, float *tangentX, float *tangentY);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgPathBounds")] 
		unsafe extern static  void PathBounds(uint path, float *minX, float *minY, float *width, float*height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgPathTransformedBounds")] 
		unsafe extern static  void PathTransformedBounds(uint path, float *minX, float *minY, float *width, float *height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDrawPath")] 
		public extern static  void DrawPath(uint path, PaintMode paintModes);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void AppendPathData(uint path, byte[] segments, Vector2[] coords)
		{
			System.Diagnostics.Debug.Assert (segments.Length == coords.Length);
			unsafe {
				fixed(byte *s=segments) {
					fixed(float *c = &coords [0].X) {
						AppendPathData (path, segments.Length, s, c);
					}
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static  void ModifyPathCoords(uint dstPath, int startIndex, int numSegments, Vector2[] coords)
		{
			unsafe {
				fixed(float *c=&coords [0].X) {
					ModifyPathCoords (dstPath, startIndex, numSegments, c);
				}
			}
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static Vector4 PointAlongPath(uint path, int startSegment, int numSegments, float distance)
		{
			Vector4 v;
			unsafe {
				PointAlongPath (path, startSegment, numSegments, distance, &v.X, &v.Y, &v.W, &v.Z);
			}
			return v;
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static Vector4 PathBounds(uint path)
		{
			Vector4 v;
			unsafe {
				PathBounds (path, &v.X, &v.Y, &v.W, &v.Z);
			}
			return v;
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static Vector4 PathTransformedBounds(uint path)
		{
			Vector4 v;
			unsafe {
				PathTransformedBounds (path, &v.X, &v.Y, &v.W, &v.Z);
			}
			return v;
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreatePaint")] 
		public extern static  uint CreatePaint();

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyPaint")] 
		public extern static  void DestroyPaint(uint paint);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetPaint")] 
		public extern static  void SetPaint(uint paint, PaintMode paintModes);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetPaint")] 
		public extern static  uint GetPaint(PaintMode paintMode);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetColor")] 
		public extern static  void SetColor(uint paint, uint rgba);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetColor")] 
		public extern static  uint GetColor(uint paint);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgPaintPattern")] 
		public extern static  void PaintPattern(uint paint, uint image);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreateImage")] 
		public extern static  uint CreateImage(ImageFormat format, int width, int height, ImageQuality allowedQuality);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyImage")] 
		public extern static  void DestroyImage(uint image);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgClearImage")] 
		public extern static  void ClearImage(uint image, int x, int y, int width, int height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgImageSubData")] 
		unsafe extern static  void ImageSubData(uint image, void * data, int dataStride, ImageFormat dataFormat, int x, int y, int width, int height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetImageSubData")] 
		unsafe extern static  void GetImageSubData(uint image, void *data, int dataStride, ImageFormat dataFormat, int x, int y, int width, int height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgChildImage")] 
		public extern static  uint ChildImage(uint imageParent, int x, int y, int width, int height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetParent")] 
		public extern static  uint GetParent(uint image); 

		[DllImport("libOpenVG-shared.so", EntryPoint="vgCopyImage")] 
		public extern static  void CopyImage(uint imageDst, int dx, int dy, uint imageSrc, int sx, int sy, int width, int height, Boolean dither);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDrawImage")] 
		public extern static  void DrawImage(uint image);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetPixels")] 
		public extern static  void SetPixels(int dx, int dy, uint imageSrc, int sx, int sy, int width, int height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgWritePixels")] 
		unsafe extern static  void WritePixels(void *data, int dataStride, ImageFormat dataFormat, int dx, int dy, int width, int height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetPixels")] 
		public extern static  void GetPixels(uint imageDst, int dx, int dy, int sx, int sy, int width, int height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgReadPixels")] 
		unsafe extern static  void ReadPixels(void *data, int dataStride, ImageFormat dataFormat, int sx, int sy, int width, int height);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgCopyPixels")] 
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

		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreateFont")] 
		public extern static uint CreateFont(int glyphCapacityHint);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyFont")] 
		public extern static void DestroyFont(uint font);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetGlyphToPath")] 
		unsafe extern static void SetGlyphToPath(uint font, uint glyphIndex, uint path, Boolean isHinted, float* glyphOrigin, float* escapement);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSetGlyphToImage")] 
		unsafe extern static void SetGlyphToImage(uint font, uint glyphIndex, uint image, float* glyphOrigin, float* escapement);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgClearGlyph")] 
		public extern static void ClearGlyph(uint font,uint glyphIndex);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDrawGlyph")] 
		public extern static void DrawGlyph(uint font, uint glyphIndex, PaintMode paintModes, Boolean allowAutoHinting);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDrawGlyphs")] 
		unsafe extern static void DrawGlyphs(uint font, int glyphCount, uint *glyphIndices, float *adjustments_x, float *adjustments_y, PaintMode paintModes, Boolean allowAutoHinting);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		// TODO: wrap unsafe

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[DllImport("libOpenVG-shared.so", EntryPoint="vgColorMatrix")] 
		unsafe extern static void ColorMatrix(uint dst, uint src, float *matrix);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgConvolve")] 
		unsafe extern static void Convolve(uint dst, uint src, int kernelWidth, int kernelHeight, int shiftX, int shiftY, short *kernel, float scale, float bias, TilingMode tilingMode);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgSeparableConvolve")] 
		unsafe extern static void SeparableConvolve(uint dst, uint src, int kernelWidth, int kernelHeight, int shiftX, int shiftY, short *kernelX, short *kernelY, float scale, float bias, TilingMode tilingMode);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGaussianBlur")] 
		public extern static void GaussianBlur(uint dst, uint src, float stdDeviationX, float stdDeviationY, TilingMode tilingMode);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgLookup")] 
		unsafe extern static void Lookup(uint dst, uint src, byte *redLUT, byte *greenLUT, byte *blueLUT, byte *alphaLUT, Boolean outputLinear, Boolean outputPremultiplied);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgLookupSingle")] 
		unsafe extern static void LookupSingle(uint dst, uint src, uint* lookupTable, ImageChannel sourceChannel, Boolean outputLinear, Boolean outputPremultiplied);

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		// TODO: wrap unsafe

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[DllImport("libOpenVG-shared.so", EntryPoint="vgHardwareQuery")] 
		public extern static HardwareQueryResult HardwareQuery(HardwareQueryType key, int setting);

		[DllImport("libOpenVG-shared.so", EntryPoint="vgGetString")] 
		unsafe extern static byte* vgGetString(StringId name);

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

		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreateBatchMNK")] 
		public extern static uint  CreateBatchMNK();

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyBatchMNK")] 
		public extern static void  DestroyBatchMNK( uint batch );

		[DllImport("libOpenVG-shared.so", EntryPoint="vgBeginBatchMNK")] 
		public extern static void BeginBatchMNK( uint batch );

		[DllImport("libOpenVG-shared.so", EntryPoint="vgEndBatchMNK")] 
		public extern static void EndBatchMNK( uint batch );

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDrawBatchMNK")] 
		public extern static void DrawBatchMNK( uint batch );

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDumpBatchMNK")] 
		unsafe extern static void DumpBatchMNK( uint batch, void **vertices, int *size );

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[DllImport("libOpenVG-shared.so", EntryPoint="vgCreateContextMNK")] 
		public extern static Boolean CreateContextMNK( int width, int height, RenderingBackendTypeMNK backend );

		[DllImport("libOpenVG-shared.so", EntryPoint="vgResizeSurfaceMNK")] 
		public extern static void ResizeSurfaceMNK( int width, int height );

		[DllImport("libOpenVG-shared.so", EntryPoint="vgDestroyContextMNK")] 
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


using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

// mapp to system intptr
using SDL_Window = System.IntPtr;
using SDL_GLContext = System.IntPtr;
using SDL_Surface = System.IntPtr;

namespace Kraggs.Interop.SDL2
{
    /// <summary>
    /// A rectangle, with the origin at the upper left.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL2Rect
    {
        public int x;
        public int y;
        public int w;
        public int h;

        #region SDL_Rect Macros

        /// <summary>
        /// Returns true if the rectangle has no area.
        /// </summary>
        [DebuggerNonUserCode()]
        public bool IsEmpty
        {
            get
            {
                return SDL2Rect.RectEmpty(this);
            }
        }

        /// <summary>
        /// Returns true if the rectangle has no area.
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [DebuggerNonUserCode()]
        public static bool RectEmpty(SDL2Rect r)
        {
            return (r.w <= 0 || r.h <= 0) ? true : false;
        }

        public static bool RectEquals(SDL2Rect a, SDL2Rect b)
        {
            return a == b;
        }

        /// <summary>
        /// Returns true if the two rectangles are equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [DebuggerNonUserCode()]
        public static bool operator == (SDL2Rect a, SDL2Rect b)
        {
            return a.x == b.x && a.y == b.y && a.w == b.w && a.h == b.h;
        }

        /// <summary>
        /// Returns true if the two rectangles are equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [DebuggerNonUserCode()]
        public static bool operator !=(SDL2Rect a, SDL2Rect b)
        {
            return a.x != b.x || a.y != b.y || a.w != b.w || a.h != b.h;
        }

        #endregion

        #region SDL_Rect Externs.

        /// <summary>
        /// Determine whether two rectangles intersect.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns>SDL_TRUE if there is an intersection, SDL_FALSE otherwise.</returns>
        [DllImport(apiSDL2.SDL2_LIBRARY, EntryPoint = "SDL_HasIntersection", CallingConvention = apiSDL2.SDL2_CALL)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HasIntersection(ref SDL2Rect A, ref SDL2Rect B);

        /// <summary>
        /// Calculate the intersection of two rectangles.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="result"></param>
        /// <returns>SDL_TRUE if there is an intersection, SDL_FALSE otherwise.</returns>
        [DllImport(apiSDL2.SDL2_LIBRARY, EntryPoint = "SDL_IntersectRect", CallingConvention = apiSDL2.SDL2_CALL)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IntersectRect(ref SDL2Rect A, ref SDL2Rect B, out SDL2Rect result);

        /// <summary>
        /// Calculate the union of two rectangles.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="result"></param>
        [DllImport(apiSDL2.SDL2_LIBRARY, EntryPoint = "SDL_UnionRect", CallingConvention = apiSDL2.SDL2_CALL)]        
        public static extern void UnionRect(ref SDL2Rect A, ref SDL2Rect B, out SDL2Rect result);


        /// <summary>
        /// Calculate a minimal rectangle enclosing a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <param name="count"></param>
        /// <param name="clip"></param>
        /// <param name="result"></param>
        /// <returns>SDL_TRUE if any points were within the clipping rect</returns>
        [DllImport(apiSDL2.SDL2_LIBRARY, EntryPoint = "SDL_EnclosePoints", CallingConvention = apiSDL2.SDL2_CALL)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnclosePoints(ref SDL2Point points, int count, ref SDL2Rect clip, out SDL2Rect result);

        /// <summary>
        /// Calculate a minimal rectangle enclosing a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <param name="clip"></param>
        /// <param name="result"></param>
        /// <returns>SDL_TRUE if any points were within the clipping rect</returns>
        [DebuggerNonUserCode()]
        public static bool EnclosePoints(SDL2Point[] points, SDL2Rect clip, out SDL2Rect result)
        {
            return EnclosePoints(ref points[0], points.Length, ref clip, out result);
        }

        /// <summary>
        /// Calculate a minimal rectangle enclosing a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <param name="clip"></param>
        /// <param name="result"></param>
        /// <returns>SDL_TRUE if any points were within the clipping rect</returns>
        [DebuggerNonUserCode()]
        public static bool EnclosePoints(SDL2Point[] points, int index, int count, SDL2Rect clip, out SDL2Rect result)
        {
            int max = (index + count) > points.Length ?
                points.Length - index : count;

            return EnclosePoints(ref points[index], max, ref clip, out result);
        }

        [DllImport(apiSDL2.SDL2_LIBRARY, EntryPoint = "SDL_IntersectRectAndLine", CallingConvention = apiSDL2.SDL2_CALL)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IntersectRectAndLine(ref SDL2Rect rect, ref int x1, ref int y1, ref int x2, ref int y2);

        #endregion
    }
}

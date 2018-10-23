﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace WpfUnmanagedOpenGL
{
    public class OpenGlHost : HwndHost
    {
        private const string DllFilePath = @"CppOpenGL.dll";

        [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr create_context(IntPtr handle, int width, int height);

        [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
        private static extern void init_gl();

        [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
        private static extern void render();

        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            var newHandle = create_context(hwndParent.Handle, (int)ActualWidth, (int)ActualHeight);
            Debug.Assert(newHandle != IntPtr.Zero);
            return new HandleRef(this, newHandle);
        }



        protected override IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            var w = this.Width;
            var h = this.Height;
            return base.WndProc(hwnd, msg, wParam, lParam, ref handled);
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            
            //init_gl();
            //base.OnRender(drawingContext);
            //render();
        }

        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            // the host will destroy the handle
        }
    }
}
// Decompiled with JetBrains decompiler
// Type: ManagedServices.WinFormsCUIFrame
// Assembly: ManagedServices, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 28B4B202-CEF1-4E0B-BB0B-6554B6259C44
// Assembly location: C:\Program Files\Autodesk\3ds Max 2016\ManagedServices.dll

using ManagedServices.Internal;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ManagedServices
{
  public class WinFormsCUIFrame
  {
    private Form mForm = form;
    private unsafe WinFormsCUIHandler* mHandler;

    public unsafe WinFormsCUIFrame(Form form)
    {
      if (form == null)
        return;
      WinFormsCUIHandler* winFormsCuiHandlerPtr1 = (WinFormsCUIHandler*) \u003CModule\u003E.MaxHeapOperators\u002Enew(128UL);
      WinFormsCUIHandler* winFormsCuiHandlerPtr2;
      // ISSUE: fault handler
      try
      {
        winFormsCuiHandlerPtr2 = (IntPtr) winFormsCuiHandlerPtr1 == IntPtr.Zero ? (WinFormsCUIHandler*) 0L : \u003CModule\u003E.ManagedServices\u002EInternal\u002EWinFormsCUIHandler\u002E\u007Bctor\u007D(winFormsCuiHandlerPtr1, form, 92U);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDelDtor((__FnPtr<void (void*)>) __methodptr(MaxHeapOperators\u002Edelete), (void*) winFormsCuiHandlerPtr1);
      }
      this.mHandler = winFormsCuiHandlerPtr2;
      this.mForm.TextChanged += new EventHandler(this.TextChanged);
      this.mForm.FormClosed += new FormClosedEventHandler(this.FormClosed);
      this.mForm.SizeChanged += new EventHandler(this.SizeChanged);
    }

    public unsafe void RemoveFrame()
    {
      if (this.mForm == null)
        return;
      this.mForm.TextChanged -= new EventHandler(this.TextChanged);
      this.mForm.FormClosed -= new FormClosedEventHandler(this.FormClosed);
      this.mForm.SizeChanged -= new EventHandler(this.SizeChanged);
      HWND__* hwndPtr1 = (HWND__*) this.mForm.Handle.ToPointer();
      if (\u003CModule\u003E.IsWindow(hwndPtr1) == 0)
        return;
      HWND__* parent = \u003CModule\u003E.GetParent(hwndPtr1);
      Interface* coreInterface = \u003CModule\u003E.GetCOREInterface();
      HWND__* hwndPtr2 = hwndPtr1;
      Interface* interfacePtr = coreInterface;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      HWND__* hwndPtr3 = __calli((__FnPtr<HWND__* (IntPtr)>) *(long*) (*(long*) interfacePtr + 272L))((IntPtr) interfacePtr);
      \u003CModule\u003E.SetParent(hwndPtr2, hwndPtr3);
      WinFormsCUIHandler* winFormsCuiHandlerPtr1 = this.mHandler;
      if ((IntPtr) winFormsCuiHandlerPtr1 != IntPtr.Zero)
        \u003CModule\u003E.ManagedServices\u002EInternal\u002EWinFormsCUIHandler\u002ERestoreStyles(winFormsCuiHandlerPtr1);
      WinFormsCUIHandler* winFormsCuiHandlerPtr2 = this.mHandler;
      if ((IntPtr) winFormsCuiHandlerPtr2 != IntPtr.Zero && (int) *(byte*) ((IntPtr) winFormsCuiHandlerPtr2 + 120L) != 0)
        return;
      this.mHandler = (WinFormsCUIHandler*) 0L;
      this.mForm = (Form) null;
      if (\u003CModule\u003E.IsWindow(parent) == 0)
        return;
      \u003CModule\u003E.DestroyWindow(parent);
    }

    public unsafe int GetDockState()
    {
      WinFormsCUIHandler* winFormsCuiHandlerPtr = this.mHandler;
      if ((IntPtr) winFormsCuiHandlerPtr == IntPtr.Zero)
        return 16;
      ICUIFrame* icuiFramePtr1 = (ICUIFrame*) *(long*) ((IntPtr) winFormsCuiHandlerPtr + 96L);
      if ((IntPtr) icuiFramePtr1 == IntPtr.Zero)
        return 16;
      ICUIFrame* icuiFramePtr2 = icuiFramePtr1;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      return (int) __calli((__FnPtr<uint (IntPtr)>) *(long*) (*(long*) icuiFramePtr2 + 144L))((IntPtr) icuiFramePtr2);
    }

    public unsafe void SetDockState(int n)
    {
      ICUIFrame* icuiFramePtr1 = (ICUIFrame*) *(long*) ((IntPtr) this.mHandler + 96L);
      if ((IntPtr) icuiFramePtr1 == IntPtr.Zero)
        return;
      ICUIFrame* icuiFramePtr2 = icuiFramePtr1;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      if ((int) __calli((__FnPtr<uint (IntPtr)>) *(long*) (*(long*) icuiFramePtr2 + 144L))((IntPtr) icuiFramePtr2) == n)
        return;
      if ((n & 15) != 0)
      {
        \u003CModule\u003E.CUIFrameMgr\u002EDockCUIWindow((CUIFrameMgr*) \u003CModule\u003E.GetCUIFrameMgrEx(), (HWND__*) *(long*) ((IntPtr) this.mHandler + 40L), n, (tagRECT*) 0L, 0);
        \u003CModule\u003E.CUIFrameMgr\u002ERecalcLayout((CUIFrameMgr*) \u003CModule\u003E.GetCUIFrameMgrEx(), 1);
      }
      else
        \u003CModule\u003E.CUIFrameMgr\u002EFloatCUIWindow((CUIFrameMgr*) \u003CModule\u003E.GetCUIFrameMgrEx(), (HWND__*) *(long*) ((IntPtr) this.mHandler + 40L), (tagRECT*) 0L, 0);
      ICUIFrame* icuiFramePtr3 = icuiFramePtr1;
      int num = n;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr, uint)>) *(long*) (*(long*) icuiFramePtr1 + 136L))((uint) icuiFramePtr3, (IntPtr) num);
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public bool IsFloating()
    {
      return ((this.GetDockState() & 15) != 0 ? 1 : 0) == 0;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public bool IsDocked()
    {
      return (this.GetDockState() & 15) != 0;
    }

    protected unsafe void SizeChanged(object sender, EventArgs e)
    {
      \u003CModule\u003E.ManagedServices\u002EInternal\u002EWinFormsCUIHandler\u002EUpdateContentPlacement(this.mHandler);
    }

    protected unsafe void TextChanged(object sender, EventArgs e)
    {
      if ((IntPtr) this.mHandler == IntPtr.Zero || this.mForm == null)
        return;
      StringConverter\u003Cwchar_t\u003E stringConverterWcharT;
      \u003CModule\u003E.WStr\u002E\u007Bctor\u007D((WStr*) &stringConverterWcharT);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.SetWindowTextW((HWND__*) *(long*) ((IntPtr) this.mHandler + 40L), \u003CModule\u003E.ManagedServices\u002EStringConverter\u003Cwchar_t\u003E\u002EConvert(&stringConverterWcharT, this.mForm.Text));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(ManagedServices\u002EStringConverter\u003Cwchar_t\u003E\u002E\u007Bdtor\u007D), (void*) &stringConverterWcharT);
      }
      \u003CModule\u003E.WStr\u002E\u007Bdtor\u007D((WStr*) &stringConverterWcharT);
    }

    protected unsafe void FormClosed(object sender, FormClosedEventArgs e)
    {
      this.RemoveFrame();
      HWND__* appHwnd = \u003CModule\u003E.CUIFrameMgr\u002EGetAppHWnd(\u003CModule\u003E.GetCUIFrameMgr());
      \u003CModule\u003E.BringWindowToTop(appHwnd);
      \u003CModule\u003E.SetFocus(appHwnd);
    }
  }
}

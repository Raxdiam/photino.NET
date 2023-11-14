using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace PhotinoNET
{
    public delegate void MenuActionDelegate();

    public class MenuBar
    {
        private static readonly JsonSerializerOptions JsonOptions = new() {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private int _id;
        
        public List<Menu> Menus { get; set; } = new();

        internal IntPtr ToNative()
        {
            _id = 0;

            var native = Marshal.AllocHGlobal(Marshal.SizeOf<MenuNative>() * Menus.Count);

            for (var i = 0; i < Menus.Count; i++) {
                var menu = Menus[i];
                var menuNative = menu.ToNative(this);
                Marshal.StructureToPtr(menuNative, native + i * Marshal.SizeOf<MenuNative>(), false);
            }

            return native;
        }

        internal int GetNextId() => _id++;

        public string ToJson(JsonSerializerOptions options = null)
        {
            return JsonSerializer.Serialize(Menus, options ?? JsonOptions);
        }
    }

    public class Menu
    {
        public string Label { get; set; }
        public bool IsSeparator { get; set; }
        public bool IsEnabled { get; set; }
        public Keys? Key { get; set; }
        public ModifierKeys Modifiers { get; set; }
        public List<Menu> SubMenus { get; set; }
        public MenuActionDelegate Action { get; set; }

        internal MenuNative ToNative(MenuBar menuBar)
        {
            var native = new MenuNative {
                LabelWide = Label,
                Label = Label,
                IsSeparator = IsSeparator,
                IsEnabled = IsEnabled,
                Modifiers = Modifiers,
                SubMenuCount = SubMenus?.Count ?? 0,
                Action = Action
            };

            if (PhotinoWindow.IsWindowsPlatform) {
                native.KeyChar = Key?.ValueWindows ?? '\0';
            }
            else if (PhotinoWindow.IsMacOsPlatform) {
                native.KeyStr = Key?.ValueMacOS;
            }

            if (SubMenus is null or { Count: 0 }) {
                if (PhotinoWindow.IsWindowsPlatform)
                    native.Id = menuBar.GetNextId();
                return native;
            }

            native.SubMenus = Marshal.AllocHGlobal(Marshal.SizeOf<MenuNative>() * SubMenus.Count);
            for (var i = 0; i < SubMenus.Count; i++) {
                var subMenu = SubMenus[i];
                var subMenuNative = subMenu.ToNative(menuBar);
                Marshal.StructureToPtr(subMenuNative, native.SubMenus + i * Marshal.SizeOf<MenuNative>(), false);
            }

            return native;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MenuNative
    {
        [MarshalAs(UnmanagedType.I4)] public int Id;
        [MarshalAs(UnmanagedType.LPWStr)] public string LabelWide;
        [MarshalAs(UnmanagedType.LPStr)] public string Label;
        [MarshalAs(UnmanagedType.I1)] public bool IsSeparator;
        [MarshalAs(UnmanagedType.I1)] public bool IsEnabled;
        [MarshalAs(UnmanagedType.LPWStr)] public string KeyLabelWide;
        [MarshalAs(UnmanagedType.LPStr)] public string KeyLabel;
        [MarshalAs(UnmanagedType.U1)]public char KeyChar;
        [MarshalAs(UnmanagedType.LPStr)] public string KeyStr;
        public ModifierKeys Modifiers;
        public IntPtr SubMenus;
        [MarshalAs(UnmanagedType.I4)] public int SubMenuCount;
        [MarshalAs(UnmanagedType.FunctionPtr)] public MenuActionDelegate Action;
    }
}
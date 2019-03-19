﻿using System.Runtime.InteropServices;
using THNETII.InteropServices.Bitwise;

namespace THNETII.WinApi.Native.WinNT
{
    // C:\Program Files (x86)\Windows Kits\10\Include\10.0.17134.0\um\winnt.h, line 11564
    /// <summary>
    /// Contains process mitigation policy settings for legacy extension point DLLs. The
    /// <see cref="GetProcessMitigationPolicy"/> and <see cref="SetProcessMitigationPolicy"/> functions use this structure.
    /// </summary>
    /// <remarks>
    /// <para>Microsoft Docs page: <a href="https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-process_mitigation_extension_point_disable_policy">PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY structure</a></para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_MITIGATION_EXTENSION_POINT_DISABLE_POLICY
    {
        private static readonly Bitfield32 bfDisableExtensionPoints = Bitfield32.DefineLowerBits(1);
        private static readonly Bitfield32 bfReservedFlags = Bitfield32.DefineFromMask(Bitmask.HigherBitsUInt32(31));

        private uint dwFlags;

        public int Flags
        {
            get => (int)dwFlags;
            set => dwFlags = (uint)value;
        }

        public bool DisableExtensionPoints
        {
            get => bfDisableExtensionPoints.Read(dwFlags) != 0;
            set => bfDisableExtensionPoints.Write(ref dwFlags, value ? 1U : 0U);
        }

        public int ReservedFlags
        {
            get => (int)bfReservedFlags.Read(dwFlags);
            set => bfReservedFlags.Write(ref dwFlags, (uint)value);
        }
    }
}

﻿using System;
using System.Runtime.InteropServices;
using THNETII.InteropServices.NativeMemory;

using static THNETII.WinApi.Native.WinNT.WinNTConstants;

namespace THNETII.WinApi.Native.WinNT
{
    // C:\Program Files (x86)\Windows Kits\10\Include\10.0.17134.0\um\winnt.h, line 8992
    /// <summary>
    /// <para>The security identifier (SID) structure is a variable-length structure used to uniquely identify users or groups.</para>
    /// <para>Applications should not modify a SID directly. To create and manipulate a security identifier, use the functions listed in the See Also section.</para>
    /// </summary>
    /// <remarks>
    /// <para>Microsoft Docs page: <a href="https://docs.microsoft.com/en-us/windows/desktop/api/Winnt/ns-winnt-_sid">SID structure</a></para>
    /// </remarks>
    /// <seealso cref="AllocateAndInitializeSid"/>
    /// <seealso cref="ConvertSidToStringSid"/>
    /// <seealso cref="ConvertStringSidToSid"/>
    /// <seealso cref="CopySid"/>
    /// <seealso cref="EqualSid"/>
    /// <seealso cref="FreeSid"/>
    /// <seealso cref="GetLengthSid"/>
    /// <seealso cref="GetSidIdentifierAuthority"/>
    /// <seealso cref="GetSidLengthRequired"/>
    /// <seealso cref="GetSidSubAuthority"/>
    /// <seealso cref="GetSidSubAuthorityCount"/>
    /// <seealso cref="InitializeSid"/>
    /// <seealso cref="IsValidSid"/>
    /// <seealso cref="LookupAccountName"/>
    /// <seealso cref="LookupAccountSid"/>
    /// <seealso href="https://msdn.microsoft.com/528412e7-c2b6-4ddd-86de-999252972421">SID Components</seealso>
    [StructLayout(LayoutKind.Sequential)]
    public struct SID
    {
        public static readonly int SECURITY_MAX_SID_SIZE =
            SizeOf<SID>.Bytes - SizeOf<int>.Bytes + (SID_MAX_SUB_AUTHORITIES * SizeOf<int>.Bytes);
        public static int SECURITY_SID_SIZE(byte SubAuthorityCount) =>
            SizeOf<SID>.Bytes - SizeOf<int>.Bytes + (SubAuthorityCount * SizeOf<int>.Bytes);

        public byte Revision;
        public byte SubAuthorityCount;
        public SID_IDENTIFIER_AUTHORITY IdentifierAuthority;
        public int SubAuthority;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PSID : IIntPtr<SID>
    {
        private static readonly int SubAuthorityOffset = Marshal.OffsetOf<SID>(nameof(SID.SubAuthority)).ToInt32();
        public PSID(IntPtr ptr) => Pointer = ptr;
        public IntPtr Pointer { get; }
        public ref byte Revision => ref Pointer.AsRefStruct<SID>().Revision;
        public ref byte SubAuthorityCount => ref Pointer.AsRefStruct<SID>().SubAuthorityCount;
        public ref SID_IDENTIFIER_AUTHORITY IdentifierAuthority => ref Pointer.AsRefStruct<SID>().IdentifierAuthority;
        public unsafe Span<int> SubAuthority
        {
            get
            {
                var ptr = Pointer;
                var count = ptr.AsRefStruct<SID>().SubAuthorityCount;
                if (count > SID_MAX_SUB_AUTHORITIES)
                    count = SID_MAX_SUB_AUTHORITIES;
                return (ptr + SubAuthorityOffset).AsRefStructSpan<int>(count);
            }
        }
    }
}

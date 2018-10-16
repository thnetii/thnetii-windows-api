﻿using System;
using System.Runtime.InteropServices;
using THNETII.InteropServices.NativeMemory;

namespace THNETII.WinApi.WinNT
{
    /// <summary>
    /// Doubly linked list structure.  Can be used as either a list head, or
    /// as link words.
    /// </summary>
    /// <remarks>
    /// All list items must be aligned on a <see cref="F:THNETII.WinApi.WinNT.WinNTConstants.MEMORY_ALLOCATION_ALIGNMENT"/> boundary. Unaligned items can cause unpredictable results. See <em>_aligned_malloc</em>.
    /// <para>Microsoft Docs page: <a href="https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_list_entry">_LIST_ENTRY structure</a></para>
    /// </remarks>
    /// <seealso cref="InitializeSListHead"/>
    /// <seealso cref="InterlockedFlushSList"/>
    /// <seealso cref="InterlockedPopEntrySList"/>
    /// <seealso cref="InterlockedPushEntrySList"/>
    [StructLayout(LayoutKind.Sequential)]
    public struct LIST_ENTRY
    {
        public PLIST_ENTRY Flink;
        public PLIST_ENTRY Blink;
    }

    /// <summary>
    /// Stringly typed pointer to a <see cref="LIST_ENTRY"/> structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PLIST_ENTRY : IIntPtr<LIST_ENTRY>
    {
        /// <summary>
        /// Initializes a new typed pointer with the specified pointer to an unspecified type.
        /// </summary>
        /// <param name="ptr">A pointer to an unspecified type.</param>
        public PLIST_ENTRY(IntPtr ptr) => Pointer = ptr;

        /// <inheritdoc />
        public IntPtr Pointer { get; }
    }
}

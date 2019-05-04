﻿using System;
using System.Runtime.InteropServices;

namespace THNETII.WinApi.Native.WinNT
{
    using static WinNTConstants;

    // C:\Program Files (x86)\Windows Kits\10\Include\10.0.17134.0\um\winnt.h, line 16651
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct ANON_OBJECT_HEADER_BIGOBJ
    {
        /* same as ANON_OBJECT_HEADER_V2 */
        /// <summary>Must be <see cref="IMAGE_FILE_MACHINE_UNKNOWN"/></summary>
        public short Sig1;
        /// <summary>Must be <c>0xffff</c></summary>
        public short Sig2;
        /// <summary>&gt;= 2 (implies the <see cref="ClassID"/> field is present)</summary>
        public short Version;
        /// <summary>Actual machine - <c>IMAGE_FILE_MACHINE_xxx</c></summary>
        public short Machine;
        public int TimeDateStamp;
        /// <summary>{D1BAA1C7-BAEE-4ba9-AF20-FAF66AA4DCB8}</summary>
        public Guid ClassID;
        /// <summary>Size of data that follows the header</summary>
        public int SizeOfData;
        /// <summary><c>0x1</c> -> contains metadata</summary>
        public int Flags;
        /// <summary>Size of CLR metadata</summary>
        public int MetaDataSize;
        /// <summary>Offset of CLR metadata</summary>
        public int MetaDataOffset;

        /* bigobj specifics */
        public int NumberOfSections; // extended from WORD
        public int PointerToSymbolTable;
        public int NumberOfSymbols;
    }
}

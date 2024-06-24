using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using THNETII.InteropServices.Memory;
using THNETII.WinApi.Native.WinError;
using Xunit;

namespace THNETII.WinApi.Native.SysInfoApi.Test
{
    using static SysInfoApiFunctions;
    using static WinErrorConstants;

    public static class GetComputerNameEx
    {
        public static IEnumerable<object[]> Get_COMPUTER_NAME_FORMAT()
        {
            var values = (COMPUTER_NAME_FORMAT[])Enum.GetValues(typeof(COMPUTER_NAME_FORMAT));
            return values
                .Where(v => (int)v < (int)COMPUTER_NAME_FORMAT.ComputerNameMax)
                .Select(v => new object[] { v })
                .ToList();
        }

        [TheoryWindowsOS]
        [MemberData(nameof(Get_COMPUTER_NAME_FORMAT))]
        public static void Can_call_lpstr_extern_function(COMPUTER_NAME_FORMAT nameType)
        {
            int length = 255;
            var buffer = Pointer.Create<LPSTR>(Marshal.AllocCoTaskMem(1 * length));
            try
            {
                bool successful = GetComputerNameExA(nameType, buffer, ref length);
                if (!successful)
                    throw Marshal.GetExceptionForHR(Marshal.GetLastWin32Error());
                var path = AnsiStringPointer.MarshalToString(buffer, length);
                Assert.NotNull(path);
            }
            finally
            {
                Marshal.FreeCoTaskMem(buffer.Pointer);
            }
        }

        [TheoryWindowsOS]
        [MemberData(nameof(Get_COMPUTER_NAME_FORMAT))]
        public static void Can_call_lpwstr_extern_function(COMPUTER_NAME_FORMAT nameType)
        {
            int length = 255;
            var buffer = Pointer.Create<LPWSTR>(Marshal.AllocCoTaskMem(2 * length));
            try
            {
                bool successful = GetComputerNameExW(nameType, buffer, ref length);
                if (!successful)
                    throw Marshal.GetExceptionForHR(Marshal.GetLastWin32Error());
                var path = UnicodeStringPointer.MarshalToString(buffer, length);
                Assert.NotNull(path);
            }
            finally
            {
                Marshal.FreeCoTaskMem(buffer.Pointer);
            }
        }

        [TheoryWindowsOS]
        [MemberData(nameof(Get_COMPUTER_NAME_FORMAT))]
        public static void Can_call_lptstr_extern_function(COMPUTER_NAME_FORMAT nameType)
        {
            int length = 255;
            var buffer = Pointer.Create<LPTSTR>(Marshal.AllocCoTaskMem(Marshal.SystemDefaultCharSize * length));
            try
            {
                bool successful = GetComputerNameEx(nameType, buffer, ref length);
                if (!successful)
                    throw Marshal.GetExceptionForHR(Marshal.GetLastWin32Error());
                var path = AutoStringPointer.MarshalToString(buffer, length);
                Assert.NotNull(path);
            }
            finally
            {
                Marshal.FreeCoTaskMem(buffer.Pointer);
            }
        }

        [TheoryWindowsOS]
        [MemberData(nameof(Get_COMPUTER_NAME_FORMAT))]
        public static void Can_call_ansi_marshaling_extern_function(COMPUTER_NAME_FORMAT nameType)
        {
            var pathBuilder = new StringBuilder();
            bool successful = GetComputerNameExA(nameType, pathBuilder, out int length);
            if (!successful)
                throw Marshal.GetExceptionForHR(Marshal.GetLastWin32Error());
            var path = pathBuilder.ToString(0, length);
            Assert.NotNull(path);
        }

        [TheoryWindowsOS]
        [MemberData(nameof(Get_COMPUTER_NAME_FORMAT))]
        public static void Can_call_unicode_marshaling_extern_function(COMPUTER_NAME_FORMAT nameType)
        {
            var pathBuilder = new StringBuilder();
            bool successful = GetComputerNameExW(nameType, pathBuilder, out int length);
            if (!successful)
                throw Marshal.GetExceptionForHR(Marshal.GetLastWin32Error());
            var path = pathBuilder.ToString(0, length);
            Assert.NotNull(path);
        }

        [TheoryWindowsOS]
        [MemberData(nameof(Get_COMPUTER_NAME_FORMAT))]
        public static void Can_call_auto_marshaling_extern_function(COMPUTER_NAME_FORMAT nameType)
        {
            var pathBuilder = new StringBuilder();
            bool successful = GetComputerNameEx(nameType, pathBuilder, out int length);
            if (!successful)
                throw Marshal.GetExceptionForHR(Marshal.GetLastWin32Error());
            var path = pathBuilder.ToString(0, length);
            Assert.NotNull(path);
        }

        [TheoryWindowsOS]
        [MemberData(nameof(Get_COMPUTER_NAME_FORMAT))]
        public static void Get_required_length_if_lpstr_is_null(COMPUTER_NAME_FORMAT nameType)
        {
            int length = 0;
            bool successful = GetComputerNameExA(nameType, default, ref length);
            Assert.False(successful);
            int error_code = Marshal.GetLastWin32Error();
            Assert.Equal(ERROR_MORE_DATA, error_code);
            Assert.NotEqual(0, length);
        }

        [TheoryWindowsOS]
        [MemberData(nameof(Get_COMPUTER_NAME_FORMAT))]
        public static void Get_required_length_if_lpwstr_is_null(COMPUTER_NAME_FORMAT nameType)
        {
            int length = 0;
            bool successful = GetComputerNameExW(nameType, default, ref length);
            Assert.False(successful);
            int error_code = Marshal.GetLastWin32Error();
            Assert.Equal(ERROR_MORE_DATA, error_code);
            Assert.NotEqual(0, length);
        }

        [TheoryWindowsOS]
        [MemberData(nameof(Get_COMPUTER_NAME_FORMAT))]
        public static void Get_required_length_if_lptstr_is_null(COMPUTER_NAME_FORMAT nameType)
        {
            int length = 0;
            bool successful = GetComputerNameEx(nameType, default, ref length);
            Assert.False(successful);
            int error_code = Marshal.GetLastWin32Error();
            Assert.Equal(ERROR_MORE_DATA, error_code);
            Assert.NotEqual(0, length);
        }

        [TheoryWindowsOS]
        [MemberData(nameof(Get_COMPUTER_NAME_FORMAT))]
        public static void Get_required_length_if_ansi_buffer_is_null(COMPUTER_NAME_FORMAT nameType)
        {
            bool successful = GetComputerNameExA(nameType, null, out int length);
            Assert.False(successful);
            int error_code = Marshal.GetLastWin32Error();
            Assert.Equal(ERROR_MORE_DATA, error_code);
            Assert.NotEqual(0, length);
        }

        [TheoryWindowsOS]
        [MemberData(nameof(Get_COMPUTER_NAME_FORMAT))]
        public static void Get_required_length_if_unicode_buffer_is_null(COMPUTER_NAME_FORMAT nameType)
        {
            bool successful = GetComputerNameExW(nameType, null, out int length);
            Assert.False(successful);
            int error_code = Marshal.GetLastWin32Error();
            Assert.Equal(ERROR_MORE_DATA, error_code);
            Assert.NotEqual(0, length);
        }

        [TheoryWindowsOS]
        [MemberData(nameof(Get_COMPUTER_NAME_FORMAT))]
        public static void Get_required_length_if_auto_buffer_is_null(COMPUTER_NAME_FORMAT nameType)
        {
            bool successful = GetComputerNameEx(nameType, null, out int length);
            Assert.False(successful);
            int error_code = Marshal.GetLastWin32Error();
            Assert.Equal(ERROR_MORE_DATA, error_code);
            Assert.NotEqual(0, length);
        }
    }
}

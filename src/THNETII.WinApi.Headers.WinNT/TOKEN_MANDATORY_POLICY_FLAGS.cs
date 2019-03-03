﻿using System;
using System.ComponentModel;

namespace THNETII.WinApi.Native.WinNT
{
    [Flags]
    public enum TOKEN_MANDATORY_POLICY_FLAGS
    {
        TOKEN_MANDATORY_POLICY_OFF = WinNTConstants.TOKEN_MANDATORY_POLICY_OFF,
        TOKEN_MANDATORY_POLICY_NO_WRITE_UP = WinNTConstants.TOKEN_MANDATORY_POLICY_NO_WRITE_UP,
        TOKEN_MANDATORY_POLICY_NEW_PROCESS_MIN = WinNTConstants.TOKEN_MANDATORY_POLICY_NEW_PROCESS_MIN,

        [EditorBrowsable(EditorBrowsableState.Never)]
        TOKEN_MANDATORY_POLICY_VALID_MASK = WinNTConstants.TOKEN_MANDATORY_POLICY_VALID_MASK,
    }
}

﻿using System;

namespace THNETII.WinApi.Native.WinNT
{
    [Flags]
    public enum FSCTL_SCRUB_DATA_INPUT_FLAGS : int
    {
        SCRUB_DATA_INPUT_FLAG_RESUME = WinNTConstants.SCRUB_DATA_INPUT_FLAG_RESUME,
        SCRUB_DATA_INPUT_FLAG_SKIP_IN_SYNC = WinNTConstants.SCRUB_DATA_INPUT_FLAG_SKIP_IN_SYNC,
        SCRUB_DATA_INPUT_FLAG_SKIP_NON_INTEGRITY_DATA = WinNTConstants.SCRUB_DATA_INPUT_FLAG_SKIP_NON_INTEGRITY_DATA,
        SCRUB_DATA_INPUT_FLAG_IGNORE_REDUNDANCY = WinNTConstants.SCRUB_DATA_INPUT_FLAG_IGNORE_REDUNDANCY,
        SCRUB_DATA_INPUT_FLAG_SKIP_DATA = WinNTConstants.SCRUB_DATA_INPUT_FLAG_SKIP_DATA,
        SCRUB_DATA_INPUT_FLAG_SCRUB_BY_OBJECT_ID = WinNTConstants.SCRUB_DATA_INPUT_FLAG_SCRUB_BY_OBJECT_ID,
    }

    [Flags]
    public enum FSCTL_SCRUB_DATA_OUTPUT_FLAGS : int
    {
        SCRUB_DATA_OUTPUT_FLAG_INCOMPLETE = WinNTConstants.SCRUB_DATA_OUTPUT_FLAG_INCOMPLETE,

        SCRUB_DATA_OUTPUT_FLAG_NON_USER_DATA_RANGE = WinNTConstants.SCRUB_DATA_OUTPUT_FLAG_NON_USER_DATA_RANGE,
        SCRUB_DATA_OUTPUT_FLAG_PARITY_EXTENT_DATA_RETURNED = WinNTConstants.SCRUB_DATA_OUTPUT_FLAG_PARITY_EXTENT_DATA_RETURNED,
        SCRUB_DATA_OUTPUT_FLAG_RESUME_CONTEXT_LENGTH_SPECIFIED = WinNTConstants.SCRUB_DATA_OUTPUT_FLAG_RESUME_CONTEXT_LENGTH_SPECIFIED,
    }
}

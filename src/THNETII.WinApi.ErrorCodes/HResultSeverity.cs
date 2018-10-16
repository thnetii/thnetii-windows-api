﻿namespace THNETII.WinApi
{
    using static WindowsProtocols.WindowsErrorCodes.Constants.WinErrorSeverityConstants;

    /// <summary>
    /// COM severity values for <see cref="HRESULT"/>.
    /// </summary>
    public enum HResultSeverity
    {
        /// <summary>Indicates a success result</summary>
        Success = SEVERITY_SUCCESS,

        /// <summary>Indicates a failure result</summary>
        Error = SEVERITY_ERROR
    }
}

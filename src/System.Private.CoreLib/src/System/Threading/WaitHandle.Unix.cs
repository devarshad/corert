// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Win32.SafeHandles;

namespace System.Threading
{
    public abstract partial class WaitHandle
    {
        private static int WaitOneCore(IntPtr handle, int millisecondsTimeout) =>
            WaitSubsystem.Wait(handle, millisecondsTimeout, true);

        internal static int WaitMultipleIgnoringSyncContext(Span<IntPtr> handles, bool waitAll, int millisecondsTimeout) =>
            WaitSubsystem.Wait(handles, waitAll, millisecondsTimeout);

        private static int SignalAndWaitCore(IntPtr handleToSignal, IntPtr handleToWaitOn, int millisecondsTimeout) =>
            WaitSubsystem.SignalAndWait(handleToSignal, handleToWaitOn, millisecondsTimeout);
    }
}

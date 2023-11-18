using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auto_VOL.Helpers
{
    class ProcessHelper
    {
        public bool CheckIfProcessIsRunning(string processName)
        {
            var process = Process.GetProcessesByName(processName);
            if (process.Any())
            {
                return true;
            }
            return false;
        }

        public async Task WhenProcessStartOrCloses(Action<int> onOpen, int onOpenParam, Action<int> onClose, int onCloseParam, string processName, CancellationToken cancellationToken)
        {
            bool lastProcessStatus = false;
            while (!cancellationToken.IsCancellationRequested) 
            {
                bool isProcessRunning = CheckIfProcessIsRunning(processName);
                bool needsToCall = lastProcessStatus != isProcessRunning;

                if (needsToCall && isProcessRunning)
                {
                    onOpen(onOpenParam);
                }
                else if (needsToCall)
                {
                    onClose(onCloseParam);
                }

                lastProcessStatus = isProcessRunning;
                await Task.Delay(1000);
            }
        }
    }
}

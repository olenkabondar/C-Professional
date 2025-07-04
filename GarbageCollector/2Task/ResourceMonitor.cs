using System.Diagnostics;
using System.Timers;

namespace _2Task
{
    internal class ResourceMonitor
    {
        private readonly long _memoryLimitBytes;
        private readonly System.Timers.Timer _timer;
        private readonly Process _currentProcess;

        public event Action<long> MemoryWarning;

        public ResourceMonitor(long memoryLimitMB, double checkIntervalSeconds = 5)
        {
            _memoryLimitBytes = memoryLimitMB * 1024 * 1024;
            _currentProcess = Process.GetCurrentProcess();

            _timer = new System.Timers.Timer(checkIntervalSeconds * 1000);
            _timer.Elapsed += CheckResources;
            _timer.AutoReset = true;
        }

        public void StartMonitoring()
        {
            _timer.Start();
        }

        public void StopMonitoring()
        {
            _timer.Stop();
        }

        private void CheckResources(object sender, ElapsedEventArgs e)
        {
            _currentProcess.Refresh(); // Оновлює інформацію про процес
            long usedMemory = _currentProcess.PrivateMemorySize64;

            if (usedMemory >= _memoryLimitBytes)
            {
                MemoryWarning?.Invoke(usedMemory);
            }
        }
    }
}

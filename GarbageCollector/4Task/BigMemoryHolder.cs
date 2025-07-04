using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Task
{
    internal class BigMemoryHolder: IDisposable
    {
        private byte[] _largeBuffer;
        private bool _disposed = false;
        public BigMemoryHolder() { }
        public BigMemoryHolder(int sizeInMB)
        {
            // Створюємо великий масив (наприклад, 100 МБ = 100 * 1024 * 1024 байтів)
            _largeBuffer = new byte[sizeInMB * 1024 * 1024];
            Console.WriteLine($"Виділено {sizeInMB} МБ пам’яті {GetHashCode()}.");
        }

        // Публічний метод для використання об’єкта
        public void Use()
        {
            if (_disposed) throw new ObjectDisposedException(nameof(BigMemoryHolder));
            Console.WriteLine("Об’єкт використовується (працює метод void Use())");
        }

        // Формалізований шаблон очищення (Dispose pattern)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // вказує GC, що фіналізатор вже не потрібен
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // звільнення керованих ресурсів
                    _largeBuffer = null;
                    Console.WriteLine($"Пам’ять звільнено вручну (virtual void Dispose(bool disposing) {GetHashCode()}).");
                }

                _disposed = true;
            }
        }

        // Деструктор 
        ~BigMemoryHolder()
        {
            Dispose(false);
            Console.WriteLine($"Пам’ять звільнено в деструкторі {GetHashCode()}.");
        }
    }
}

namespace PersonelTayin.Helpers
{
    public static class LogHelper
    {
        private static readonly string logPath = Path.Combine("Logs", "log.txt");

        public static void Log(string message) // 💥 bu methodun adı kesinlikle Log olmalı
        {
            try
            {
                var directory = Path.GetDirectoryName(logPath);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
                }
            }
            catch
            {
                // log hatasını loglama :)
            }
        }
    }
}

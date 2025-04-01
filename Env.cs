namespace SparkNET.DotEnv
{
    public static class Env
    {
        private static Dictionary<string, string> _data = [];

        public static void Load(string? path = null)
        {
            path = string.IsNullOrWhiteSpace(path) ? ".env" : path;
            if (!File.Exists(path))
            {
                throw new Exception("The .env file not found!");
            }

            _data = [];
            var lines = File.ReadAllLines(path);
            foreach (var item in lines)
            {
                string line = item.Trim();
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith('#')) continue;

                var kvp = line.Split('=', 2);
                if (kvp.Length != 2) continue;
                
                var key = kvp[0].Trim();
                var value = kvp[1].Trim();

                if (string.IsNullOrWhiteSpace(key)) continue;
                if (string.IsNullOrWhiteSpace(value)) continue;
                _data[key] = value;
            }
        }

        public static T Get<T>(string key, T fallback = default!)
        {
            if (!_data.TryGetValue(key, out string? value)) return fallback;
            try { return (T)Convert.ChangeType(value, typeof(T)); }
            catch { return fallback; }
        }
    }
}

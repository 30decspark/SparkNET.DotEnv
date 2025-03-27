namespace SparkNET.DotEnv
{
    public static class Env
    {
        private static Dictionary<string, string> _data = [];

        public static void Load()
        { 
            string path = ".env";
            if (!File.Exists(path))
            {
                throw new Exception("The .env file does not exist!");
            }

            _data = [];
            var lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line.Trim()) || line.Trim().StartsWith('#'))
                {
                    continue;
                }

                var kvp = line.Split('=', 2);
                if (kvp.Length == 2)
                {
                    var key = kvp[0].Trim();
                    var value = kvp[1].Trim();

                    if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
                    {
                        _data[key] = value;
                    }
                }
            }
        }
    }
}

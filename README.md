## Usage

To use **SparkNET.DotEnv** for load .env file.

### Example Code:

```csharp
using SparkNET.DotEnv;

// Load
Env.Load();

// Retrieve
bool isLock = Env.Get<bool>("ISLOCK", false);
```
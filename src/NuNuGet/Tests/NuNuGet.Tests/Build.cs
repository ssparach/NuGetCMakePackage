namespace NuNuGet.Tests;

using System;
using System.IO;

internal static class Build
{
    public static string GetRootPath()
    {
        DirectoryInfo? directory = new DirectoryInfo(Path.GetDirectoryName(typeof(ScenarioTests).Assembly.Location)!);
        while (directory is not null)
        {
            if (File.Exists(Path.Combine(directory.FullName, "NuNuGet.slnx")))
            {
                return directory.FullName;
            }

            directory = directory.Parent;
        }

        throw new InvalidOperationException("Unable to locate the NuNuGet source root.");
    }

    public static string GetConfiguration()
    {
#if DEBUG
        return "Debug";
#else
        return "Release";
#endif
    }
}

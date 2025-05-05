using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ProjectTemplate.Panels
{
    /// <summary>
    /// This panel is used to create a new project based on this template.
    /// </summary>
    public static class NewProject
    {
        /// <summary>
        /// Contents of the project readme file in MD (Markdown Documentation) format
        /// </summary>
        public static string Readme => File.ReadAllText("README.md");

        // Converts a project name to a valid namespace in CamelCase format
        private static string ToCamelCase(string projectName)
        {
            return Regex.Replace(projectName.Trim(), @"(?:^|\s)([a-z])", m => m.Groups[1].Value.ToUpper(System.Globalization.CultureInfo.CurrentCulture)).Replace(" ", null);
        }

        /// <summary>
        /// Creates a new project based on this template.
        /// </summary>
        /// <param name="projectName">Assign a project name</param>
        public static void CreateNewProject(string projectName)
        {
            if (!Debugger.IsAttached)
            {
                throw new Exception("This method is only available in debug mode.");
            }
            var sourcePath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent;
            var projectNameCamelCase = ToCamelCase(projectName);
            var targetPath = new DirectoryInfo(Path.Combine(sourcePath.Parent.FullName, projectNameCamelCase));

            // Ensure source exists
            if (sourcePath.GetFiles("*.csproj").Length == 0)
                throw new Exception($"Source directory '{sourcePath}' not found!");

            if (targetPath.Exists)
                throw new Exception($"Target directory '{targetPath}' already exists!");

            targetPath.Create();
            foreach (var file in Directory.GetFiles(sourcePath.FullName, "*", SearchOption.AllDirectories))
            {
                string relativePath = file.Substring(sourcePath.FullName.Length + 1);

                // Skip bin, obj, hidden and compiler-generated directories
                if (relativePath.StartsWith("bin") || relativePath.StartsWith("obj") || relativePath.StartsWith("."))
                    continue;
                string newFilePath = Path.Combine(targetPath.FullName, relativePath.Replace("ProjectTemplate", ToCamelCase(projectNameCamelCase)));

                string newFileDir = Path.GetDirectoryName(newFilePath);

                // Ensure the directory exists
                Directory.CreateDirectory(newFileDir);

                // Read & replace content
                string content = File.ReadAllText(file);
                content = content.Replace("ProjectTemplate", ToCamelCase(projectNameCamelCase));

                File.WriteAllText(newFilePath, content);
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var projectFile = targetPath.GetFiles("*.csproj").FirstOrDefault();
                if (projectFile != null)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = projectFile.FullName,
                        UseShellExecute = true
                    });
                }
            }
        }
    }
}

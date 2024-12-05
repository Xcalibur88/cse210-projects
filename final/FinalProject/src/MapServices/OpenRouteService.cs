namespace FinalProject.Maps;

using System;
using System.Diagnostics;

class OpenRouteService() {
    private Process orsProcess;
    private static readonly ProcessStartInfo startInfo = new() {
        FileName = "java",
        Arguments = "-jar data/ors.jar", //-Dors.engine.config_output=ors-config.yml
        CreateNoWindow = false,  // Set to false if you want to see the console window
        UseShellExecute = false,
        RedirectStandardOutput = true,
        RedirectStandardError = true
    };


    public void StartORS() {
        var existingProcesses = Process.GetProcessesByName("java");
        Process[] processes = Process.GetProcesses();
        foreach (var process in processes) {
            Console.WriteLine(process.MainWindowTitle);
            if (process.MainWindowTitle.Contains("openrouteservice")) {
                Console.WriteLine("ORS is already running!");
                orsProcess = process;
            }
        }
        
        orsProcess = new Process { StartInfo = startInfo };
        
        // orsProcess.OutputDataReceived += (sender, args) => Console.WriteLine($"ORS: {args.Data}");
        orsProcess.ErrorDataReceived += (sender, args) => {
            if (!string.IsNullOrEmpty(args.Data))
                Console.WriteLine($"ORS Error: {args.Data}");
            else
                Console.WriteLine("ORS Error: No error message provided.");
        };
        try {
            orsProcess.Start();
            orsProcess.BeginOutputReadLine();
            orsProcess.BeginErrorReadLine();
        } catch (Exception ex) {
            Console.WriteLine($"Error starting ORS: {ex.Message}");
        }

        Console.WriteLine("OpenRouteService starting...");
    }

    public void StopORS() {
        if (orsProcess != null && !orsProcess.HasExited) {
            orsProcess.Kill();
            orsProcess.Dispose();
            Console.WriteLine("OpenRouteService stopped.");
        }
    }
}
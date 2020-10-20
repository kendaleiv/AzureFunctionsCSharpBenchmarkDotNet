using BenchmarkDotNet.Attributes;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace FunctionAppBenchmark
{
    [InProcess]
    public class Benchmarks
    {
        private const int FunctionsPort = 7071;

        private Process funcProcess;
        private HttpClient httpClient;

        [GlobalSetup]
        public void GlobalSetup()
        {
            funcProcess = new Process
            {
                StartInfo =
                {
                    FileName = "func.exe",
                    Arguments = $"start -p {FunctionsPort}",
                    WorkingDirectory = "src/FunctionApp"
                }
            };

            var started = funcProcess.Start();

            if (!started)
            {
                throw new Exception("func.exe was not started.");
            }

            httpClient = new HttpClient
            {
                BaseAddress = new Uri($"http://localhost:{FunctionsPort}")
            };
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            if (!funcProcess.HasExited)
            {
                funcProcess.Kill();
            }
        }

        [Benchmark]
        public async Task FastEndpoint()
        {
            var response = await httpClient.GetAsync("/api/run");

            response.EnsureSuccessStatusCode();
        }

        [Benchmark]
        public async Task SlowEndpoint()
        {
            var response = await httpClient.GetAsync("/api/run-slow");

            response.EnsureSuccessStatusCode();
        }
    }
}

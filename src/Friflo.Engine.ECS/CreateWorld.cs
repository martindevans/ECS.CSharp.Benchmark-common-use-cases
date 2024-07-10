﻿using BenchmarkDotNet.Attributes;

namespace Friflo.Engine.ECS;

[ShortRunJob]
public class CreateWorld
{
    [Benchmark(Baseline = true)]
    public void Run()
    {
        _ = new EntityStore();
        // nothing to Dispose() - has no unmanaged resources
    }
}
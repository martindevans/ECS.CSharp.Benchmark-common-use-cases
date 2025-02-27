﻿using BenchmarkDotNet.Attributes;

namespace TinyEcs;

[BenchmarkCategory(Category.CommandBufferAddRemoveT2)]
// ReSharper disable once InconsistentNaming
public class CommandBufferAddRemoveT2_TinyEcs
{
    private World           world;
    private EntityView[]    entities;
    
    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entities    = world.CreateEntities(Constants.EntityCount);
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }

    [Benchmark]
    public void Run()
    {
        world.BeginDeferred();
        foreach (var entity in entities) {
            entity
                .Set(new Component1())
                .Set(new Component2());
        }
        world.EndDeferred(); // Apply changes 1
        
        world.BeginDeferred();
        foreach (var entity in entities) {
            entity
                .Unset<Component1>()
                .Unset<Component2>();
        }
        world.EndDeferred(); // Apply changes 2
    }
}
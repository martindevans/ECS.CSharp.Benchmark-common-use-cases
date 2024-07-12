﻿using BenchmarkDotNet.Attributes;

namespace fennecs;

[BenchmarkCategory(Category.DeleteEntity)]
// ReSharper disable once InconsistentNaming
public class DeleteEntity_Fennecs
{
    private World       world;
    private Entity[]    entities;
    
    [IterationSetup]
    public void Setup()
    {
        world       = new World();
        entities    = world.CreateEntities(Constants.DeleteEntityCount).AddComponents();
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities) {
            entity.Despawn();
        }
    }
}
﻿using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[BenchmarkCategory(Category.DeleteEntity)]
// ReSharper disable once InconsistentNaming
public class DeleteEntity_Leopotam
{
    private EcsWorld    world;
    private int[]       entities;
    
    [IterationSetup]
    public void Setup()
    {
        world       = new EcsWorld();
        entities    = world.CreateEntities(Constants.DeleteEntityCount).AddComponents(world);
    }
    
    [IterationCleanup]
    public void Shutdown()
    {
        world.Destroy();
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities) {
            world.DelEntity(entity);
        }
    }
}
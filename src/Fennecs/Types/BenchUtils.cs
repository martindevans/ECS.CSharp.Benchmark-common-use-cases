﻿using fennecs;

namespace Fennecs.Types;

public static class BenchUtils
{
    public static Entity[] CreateEntities (World world, int count)
    {
        var entities = new Entity[count];
        for (int n = 0; n < count; n++) {
            entities[n] = world.Spawn(); 
        }
        return entities;
    }
    
    public static Entity[] AddComponents(Entity[] entities)
    {
        foreach (var entity in entities)
        {
            entity.Add<Component1>();
            entity.Add<Component2>();
            entity.Add<Component3>();
            entity.Add<Component4>();
            entity.Add<Component5>();
        }
        return entities;
    }
}
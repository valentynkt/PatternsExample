using System.Collections.Generic;

namespace TemplateMethod.Conceptual
{
    // Abstract class that defines the template method and abstract methods
    public abstract class GameAI
    {
        // Template method that defines the skeleton of the algorithm
        public void Turn()
        {
            CollectResources();
            BuildStructures();
            BuildUnits();
            Attack();
        }

        // Default implementation of a method in the base class
        public virtual void CollectResources()
        {
            foreach (var structure in BuiltStructures)
            {
                structure.Collect();
            }
        }

        // Abstract methods to be implemented by subclasses
        public abstract void BuildStructures();
        public abstract void BuildUnits();

        public void Attack()
        {
            var enemy = ClosestEnemy();
            if (enemy == null)
            {
                SendScouts(new Position(map.Center));
            }
            else
            {
                SendWarriors(enemy.Position);
            }
        }

        public abstract void SendScouts(Position position);
        public abstract void SendWarriors(Position position);

        // Example properties and methods to support the game logic
        protected List<Structure> BuiltStructures { get; set; }
        protected Map map { get; set; }

        protected virtual Enemy ClosestEnemy()
        {
            return new Enemy(); // Dummy implementation
        }
    }

    // Concrete class implementing the abstract operations
    public class OrcsAI : GameAI
    {
        public override void BuildStructures()
        {
            if (ResourcesAvailable)
            {
                // Build farms, then barracks, then stronghold
            }
        }

        public override void BuildUnits()
        {
            if (ResourcesPlentiful)
            {
                if (!ScoutsExist)
                {
                    // Build peon, add it to scouts group
                }
                else
                {
                    // Build grunt, add it to warriors group
                }
            }
        }

        public override void SendScouts(Position position)
        {
            if (Scouts.Count > 0)
            {
                // Send scouts to position
            }
        }

        public override void SendWarriors(Position position)
        {
            if (Warriors.Count > 5)
            {
                // Send warriors to position
            }
        }

        // Example properties to support the game logic
        protected bool ResourcesAvailable { get; set; }
        protected bool ResourcesPlentiful { get; set; }
        protected bool ScoutsExist { get; set; }
        protected List<Unit> Scouts { get; set; }
        protected List<Unit> Warriors { get; set; }
    }

    // Another concrete class with some overridden methods
    public class MonstersAI : GameAI
    {
        public override void CollectResources()
        {
            // Monsters don't collect resources
        }

        public override void BuildStructures()
        {
            // Monsters don't build structures
        }

        public override void BuildUnits()
        {
            // Monsters don't build units
        }

        public override void SendScouts(Position position)
        {
            // Possibly implement a different way to handle scouting
        }

        public override void SendWarriors(Position position)
        {
            // Implement a monster-specific way to handle attacks
        }
    }

    // Supporting classes and structs
    public class Structure
    {
        public void Collect() { }
    }

    public class Position
    {
        public Position(int center) { }
    }

    public class Map
    {
        public int Center { get; set; }
    }

    public class Unit
    {
        public string Name { get; set; }
    }
    public class Enemy
    {
        public Position Position { get; set; }
    }
}

using System;

namespace Chicken
{
    public interface IBird
    {
        Egg Lay();
    }

    public class Chicken : IBird
    {
        public Chicken()
        {
            System.WriteLine("A New Chicken!");
        }

        public Egg Lay()
        {
            return new Egg(new Func<Chicken>(() => new Chicken()));
        }
    }

    public class Egg
    {
        private Func<IBird> kind;
        private bool Hatched = false;
        public Egg(Func<IBird> createBird)
        {
            kind = createBird;
        }

        public IBird Hatch()
        {
            if (Hatched)
            {
                throw new System.InvalidOperationException("Invalid, Egg Already Hatched");
            }
            else
            {
                Hatched = true;
                return kind();
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var chicken1 = new Chicken();
            var egg = chicken1.Lay();
            var childChicken = egg.Hatch();
            var childChicken2 = egg.Hatch();
        }
    }
}

using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace PatternCreazionali
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactoryAnimal factory = new FactoryAnimal();

            var animal = factory.GetInstance("Leon");
           // Console.WriteLine(animal.Voice());

            
            #region  Singleton
            var panda1 = factory.GetInstance("Panda");
            var panda2 = factory.GetInstance("Panda");

            //Console.WriteLine(panda1.Equals(panda2));

            #endregion

            #region lazyLoad
            var snake = new Snake();
            //Console.WriteLine(snake.Terrain.Id);
            #endregion

            #region  Prototype
            var hamster1 = new Hamster();
            hamster1.Age = 10;
            var hamster2 = hamster1.Clone();
            hamster2.Age = 30;

            Console.WriteLine(hamster1.Age == hamster2.Age);
            Console.WriteLine(hamster1 == hamster2);
            #endregion
            
            #region IoC
            Console.Clear();
            var services = new ServiceCollection();
            services.AddScoped<Dog>();
            services.AddScoped<Cat>();
            services.AddSingleton<Water>();
            services.AddScoped<Tadpole>();
            services.AddScoped<Frog>(sp =>
            {
                return FrogBuilder.BuildFrog(sp.GetService<Water>(), sp.GetService<Tadpole>());
            });
            services.AddScoped<Leon>(_ => Leon.CreateLeon());
            services.AddSingleton<Panda>( _=> Panda.GetInstance());
            services.AddScoped<IFactoryAnimal, FactoryAnimalIoC>(sp => new FactoryAnimalIoC(sp));

            var serviceProvider = services.BuildServiceProvider();

            var factoryIoC = serviceProvider.GetService<IFactoryAnimal>();
            var animalIoC = factoryIoC.GetInstance("Panda");
            Console.WriteLine(animalIoC.Voice());

            #region  Singleton
            var water1 = serviceProvider.GetService<Water>();
            var water2 = serviceProvider.GetService<Water>();

            Console.WriteLine(water1.Equals(water2));

            #endregion

            #endregion
        }
    }

    public interface IAnimal
    {
        string Voice();
    }
    public interface IFactoryAnimal
    {
        IAnimal GetInstance(string typeAnimal);
    }


    public class FactoryAnimal : IFactoryAnimal
    {
        public IAnimal GetInstance(string typeAnimal)
        {
            return typeAnimal switch
            {
                "Dog" => new Dog(),
                "Cat" => new Cat(),
                #region Factory Method
                "Leon" => Leon.CreateLeon(),
                #endregion
                #region  Builder
                "Frog" => FrogBuilder.BuildFrog(new Water(), new Tadpole()),
                #endregion
                #region Singleton
                "Panda" => Panda.GetInstance(),
                #endregion
                _ => throw new NotImplementedException()
            };
        }
    }
    public class Dog : IAnimal
    {
        public string Voice()
        {
            return "Bau";
        }
    }

    public class Cat : IAnimal
    {
        public string Voice()
        {
            return "Miao";
        }
    }

    #region Factory Method
    public class Leon : IAnimal
    {
        private Leon() { }
        public static Leon CreateLeon()
        {
            // una serie di operazioni prima della creazione
            return new Leon();
        }

        public string Voice()
        {
            return "GRRRRR";
        }
    }

    #endregion

    #region Builder
    public class Frog : IAnimal
    {
        public string Voice()
        {
            return "Crack";
        }
    }
    public class Water
    {

    }

    public class Tadpole
    {

    }

    public static class FrogBuilder
    {
        public static Frog BuildFrog(Water water, Tadpole tadpole)
        {
            return new Frog();
        }
    }

    #endregion

    #region singleton
    public class Panda : IAnimal
    {
        private static Panda instance;
        private Panda()
        {

        }

        public static Panda GetInstance()
        {
            if (instance == null)
                instance = new Panda();

            return instance;
        }

        public string Voice()
        {
            return "Poo";
        }
    }
    #endregion

    #region lazyLoad
    public class Terrain
    {
        public Terrain()
        {
            Id = 1;
        }
        public int Id {get;set;}
    }
    public class Snake : IAnimal
    {
        public Snake()
        {

        }
        private Terrain _Terrain;
        public Terrain Terrain { 
            get
            {
                Console.WriteLine(_Terrain is null);
                if(_Terrain is null )
                    _Terrain = new Terrain();

                Console.WriteLine(_Terrain is null);
                return _Terrain;
            }
            set
            {
                _Terrain = value;
            }
    }
        public string Voice()
        {
            return "ppssss";
        }
    }
    #endregion

    #region Prototype
    public class Hamster : IAnimal
    {
        public int Age {get; set;}
        public string Voice()
        {
            return "Squit";
        }

        public Hamster Clone()
        {
            return (Hamster) this.MemberwiseClone();
        }
    }
    #endregion

    #region FactoryIoc

    public class FactoryAnimalIoC : IFactoryAnimal
    {
        private readonly IServiceProvider provider;
        public FactoryAnimalIoC(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public IAnimal GetInstance(string typeAnimal)
        {
            return typeAnimal switch
            {
                "Dog" => provider.GetService<Dog>(),
                "Cat" => provider.GetService<Cat>(),
                "Leon" => provider.GetService<Leon>(),
                "Frog" => provider.GetService<Frog>(),
                "Panda" => provider.GetService<Panda>(),
                _ => throw new NotImplementedException()
            };
        }
    }
    #endregion

}

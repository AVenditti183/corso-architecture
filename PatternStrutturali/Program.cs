using System;
using System.Linq;
using System.Collections.Generic;

namespace PatternStrutturali
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Adapter
            var client = new Client();
            var server = new Server();
            var Adapter = new AdpaterStampa(client, server);
            Adapter.Stampa();
            #endregion

            #region Bridge
            var Bridge = new Bridge();
            Bridge.Operation = new StampaNormale();
            //Bridge.Stampa("ABC");

            Bridge.Operation = new StampaReverse();
            //Bridge.Stampa("ABC");
            #endregion

            #region  Composite
            ClientComposite clientComposite = new ClientComposite();

            // This way the client code can support the simple leaf
            // components...
            Leaf leaf = new Leaf();
            //Console.WriteLine("Client: I get a simple component:");
            //clientComposite.ClientCode(leaf);

            // ...as well as the complex composites.
            Composite tree = new Composite();
            Composite branch1 = new Composite();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());
            Composite branch2 = new Composite();
            branch2.Add(new Leaf());
            tree.Add(branch1);
            tree.Add(branch2);
            //Console.WriteLine("Client: Now I've got a composite tree:");
            //clientComposite.ClientCode(tree);
            #endregion

            #region Decoretor
            var simple = new ConcreteComponent();

            //Console.WriteLine(simple.Operation());

            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            //Console.WriteLine(decorator1.Operation());
            //Console.WriteLine(decorator2.Operation());
            #endregion

            #region  Facade
            var facade = new Facade();
            //Console.WriteLine(facade.Operazione());
            #endregion
        }

        #region Adapter
        public interface IClient
        {
            void Stampa(string testo);
        }
        public class Client : IClient
        {
            public void Stampa(string testo)
            {
                Console.WriteLine(testo);
            }
        }
        public interface IServer
        {
            int CoseDaStampare();
        }

        public class Server : IServer
        {
            public int CoseDaStampare() => 3;
        }
        public class AdpaterStampa
        {
            private readonly IClient client;
            private readonly IServer server;

            public AdpaterStampa(IClient client, IServer server)
            {
                this.client = client;
                this.server = server;
            }

            public void Stampa()
            {
                var info = server.CoseDaStampare();
                client.Stampa(info.ToString());
            }
        }
        #endregion

        #region Bridge
        public abstract class Operation
        {
            public abstract void EseguiStampa(string testo);
        }

        public class Bridge
        {
            private Operation operation;
            public Operation Operation
            {
                set
                {
                    operation = value;
                }
            }

            public void Stampa(string testo)
            {
                operation.EseguiStampa(testo);
            }
        }

        public class StampaNormale : Operation
        {
            public override void EseguiStampa(string testo) => Console.WriteLine(testo);
        }

        public class StampaReverse : Operation
        {
            public override void EseguiStampa(string testo) => Console.WriteLine(string.Join("", testo.Reverse()));
        }
        #endregion

        #region  Composite
        abstract class Component
        {
            public Component() { }

            // The base Component may implement some default behavior or leave it to
            // concrete classes (by declaring the method containing the behavior as
            // "abstract").
            public abstract string Operation();

            // In some cases, it would be beneficial to define the child-management
            // operations right in the base Component class. This way, you won't
            // need to expose any concrete component classes to the client code,
            // even during the object tree assembly. The downside is that these
            // methods will be empty for the leaf-level components.
            public virtual void Add(Component component)
            {
                throw new NotImplementedException();
            }

            public virtual void Remove(Component component)
            {
                throw new NotImplementedException();
            }

            // You can provide a method that lets the client code figure out whether
            // a component can bear children.
            public virtual bool IsComposite()
            {
                return true;
            }
        }

        // The Leaf class represents the end objects of a composition. A leaf can't
        // have any children.
        //
        // Usually, it's the Leaf objects that do the actual work, whereas Composite
        // objects only delegate to their sub-components.
        class Leaf : Component
        {
            public override string Operation()
            {
                return "Leaf";
            }

            public override bool IsComposite()
            {
                return false;
            }
        }

        // The Composite class represents the complex components that may have
        // children. Usually, the Composite objects delegate the actual work to
        // their children and then "sum-up" the result.
        class Composite : Component
        {
            protected List<Component> _children = new List<Component>();

            public override void Add(Component component)
            {
                this._children.Add(component);
            }

            public override void Remove(Component component)
            {
                this._children.Remove(component);
            }

            // The Composite executes its primary logic in a particular way. It
            // traverses recursively through all its children, collecting and
            // summing their results. Since the composite's children pass these
            // calls to their children and so forth, the whole object tree is
            // traversed as a result.
            public override string Operation()
            {
                int i = 0;
                string result = "Branch(";

                foreach (Component component in this._children)
                {
                    result += component.Operation();
                    if (i != this._children.Count - 1)
                    {
                        result += "+";
                    }
                    i++;
                }

                return result + ")";
            }
        }

        class ClientComposite
        {
            // The client code works with all of the components via the base
            // interface.
            public void ClientCode(Component leaf)
            {
                Console.WriteLine($"RESULT: {leaf.Operation()}\n");
            }

            // Thanks to the fact that the child-management operations are declared
            // in the base Component class, the client code can work with any
            // component, simple or complex, without depending on their concrete
            // classes.
            public void ClientCode2(Component component1, Component component2)
            {
                if (component1.IsComposite())
                {
                    component1.Add(component2);
                }

                Console.WriteLine($"RESULT: {component1.Operation()}");
            }
        }
        #endregion

        #region Decoretor
        abstract class ComponentDecoretor
        {
            public abstract string Operation();
        }
        class ConcreteComponent : ComponentDecoretor
        {
            public override string Operation()
            {
                return "ConcreteComponent";
            }
        }
        abstract class Decorator : ComponentDecoretor
        {
            protected ComponentDecoretor _component;

            public Decorator(ComponentDecoretor component)
            {
                this._component = component;
            }

            public void SetComponent(ComponentDecoretor component)
            {
                this._component = component;
            }

            // The Decorator delegates all work to the wrapped component.
            public override string Operation()
            {
                if (this._component != null)
                {
                    return this._component.Operation();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        class ConcreteDecoratorA : Decorator
        {
            public ConcreteDecoratorA(ComponentDecoretor comp) : base(comp)
            {
            }

            // Decorators may call parent implementation of the operation, instead
            // of calling the wrapped object directly. This approach simplifies
            // extension of decorator classes.
            public override string Operation()
            {
                return $"ConcreteDecoratorA({base.Operation()})";
            }
        }

        // Decorators can execute their behavior either before or after the call to
        // a wrapped object.
        class ConcreteDecoratorB : Decorator
        {
            public ConcreteDecoratorB(ComponentDecoretor comp) : base(comp)
            {
            }

            public override string Operation()
            {
                return $"ConcreteDecoratorB({base.Operation()})";
            }
        }
        #endregion

        #region  Facade
        class System1
        {
            public string Operazione1() => "Operazione1";
            public string Operazione2() => "Operazione2";
        }

        class System2
        {
            public string OperazioneA() => "OperazioneA";
            public string OperazioneB() => "OperazioneB";
        }

        class Facade
        {
            private readonly System1 system1;
            private readonly System2 system2;

            public Facade()
            {
                system1 = new System1();
                system2 = new System2();
            }

            public string Operazione()
            {

                return string.Join(" ", new string[]
                {
                    system1.Operazione1(),
                    system1.Operazione2(),
                    system2.OperazioneA(),
                    system2.OperazioneB()
                    }
                    );
            }
        }

        #endregion
    }
}

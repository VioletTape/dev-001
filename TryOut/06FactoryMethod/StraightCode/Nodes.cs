using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOut._06FactoryMethod.StraightCode
{
    internal abstract class Node
    {
       public abstract NodeType Type { get; }
    }

    internal enum NodeType : short
    {
        Undefined = 0,
        Company = 1,
        Person = 2,
        NonProfitFoundation = 3
    }

    internal class CompanyNode : Node
    {
        public override NodeType Type => NodeType.Company;
    }

    internal class PersonNode : Node
    {
        public override NodeType Type => NodeType.Person;
    }

    internal class NonProfitFoundationNode : Node
    {
        public override NodeType Type => NodeType.NonProfitFoundation;
    }

    internal class NodeFactory{
        public Node Create(string url)
        {
            if (url.StartsWith("c:"))
            {
                return new CompanyNode();
            }
            if (url.StartsWith("p:"))
            {
                return new PersonNode();
            }
            if (url.StartsWith("n:"))
            {
                return new NonProfitFoundationNode();
            }

            throw new ArgumentException("Not supported node type");
        }
    }
}
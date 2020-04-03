using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SOLID_Principles
{
    //Genealogy research app // simulation


    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
    }

    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> _relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            _relations.Add((parent, Relationship.Parent, child));
            _relations.Add((child, Relationship.Child, parent));
        }

        //public List<(Person, Relationship, Person)> Relations => _relations;
        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return _relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent).Select(r => r.Item3);
        }
    }


    public class Research
    {
        public Research(IRelationshipBrowser browser)
        {
            foreach (var c in browser.FindAllChildrenOf("Cristian"))
            {
                Console.WriteLine($"Cristian has a child called {c.Name}");
            }
        }
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }
    
    public class D
    {
        //Dependency inversion principle
    }
}
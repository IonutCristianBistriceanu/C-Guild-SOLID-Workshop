
namespace SOLID_Principles
{
    class Program
    {
        static void Main(string[] args)
        {
           var parent = new Person(){Name = "Cristian"};
           var child1 = new Person(){Name = "Alex"};
           var child2 = new Person(){Name = "Oana"};
           
           
           var relationships = new Relationships();
           relationships.AddParentAndChild(parent, child1);
           relationships.AddParentAndChild(parent, child2);
           
           
           var rc = new Research(relationships);

        }
    }
}
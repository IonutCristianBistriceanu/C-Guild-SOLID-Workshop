using System.Collections.Generic;

namespace SOLID_Principles
{
    //Web ordering system with filters

    public enum Color
    {
        Green,
        Blue,
        Red
    }

    public enum Size
    {
        Small,
        Medium,
        Large
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                    yield return p;
            }
        }


        public IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var p in products)
            {
                if (p.Size == size && p.Color == color)
                    yield return p;
            }
        }
    }


    //Solution will be using inheritance and generics
    //Enterprise pattern / specification patters

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> products, ISpecification<T> specification);
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products, ISpecification<Product> specification)
        {
            foreach (var p in products)
            {
                if (specification.IsSatisfied(p))
                {
                    yield return p;
                }
            }
        }
    }


    public class ColorSpecification : ISpecification<Product>
    {
        private readonly Color _color;

        public ColorSpecification(Color color)
        {
            _color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Color == _color;
        }
    }


    public class SizeSpecification : ISpecification<Product>
    {
        private readonly Size _size;

        public SizeSpecification(Size size)
        {
            _size = size;
        }


        public bool IsSatisfied(Product t)
        {
            return t.Size == _size;
        }
    }

    public class O
    {
        //Open-Closed Principle
    }
}
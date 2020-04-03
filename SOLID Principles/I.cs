namespace SOLID_Principles
{
    //Document and printer system

    public class Document
    {
    }

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionalMachine : IMachine
    {
        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }

        public void Fax(Document d)
        {
            //
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            throw new System.NotImplementedException();
        }

        public void Fax(Document d)
        {
            throw new System.NotImplementedException();
        }
    }


    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }


    public interface IPhotoCopyMachine : IPrinter, IScanner
    {
    }

    public class PhotoCopyMachine : IPhotoCopyMachine
    {
        private IPrinter _printer;
        private IScanner _scanner;

        public PhotoCopyMachine(IPrinter printer, IScanner scanner)
        {
            _printer = printer;
            _scanner = scanner;
        }

        public void Scan(Document d)
        {
            _scanner.Scan(d);
            //Decorator pattern
        }

        public void Print(Document d)
        {
            _printer.Print(d);
        }
    }


    public class I
    {
        //Interface segregation principle       
    }
}

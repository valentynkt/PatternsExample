using System;

namespace Decorator.Conceptual
{
    // Component Interface
    interface IDataSource
    {
        void WriteData(string data);
        string ReadData();
    }

    // Concrete Component: FileDataSource
    class FileDataSource : IDataSource
    {
        private readonly string _filename;

        public FileDataSource(string filename)
        {
            _filename = filename;
        }

        public void WriteData(string data)
        {
            Console.WriteLine($"Writing data to {_filename}: {data}");
        }

        public string ReadData()
        {
            Console.WriteLine($"Reading data from {_filename}");
            return "Mock data from file";
        }
    }

    // Base Decorator Class
    class DataSourceDecorator : IDataSource
    {
        protected IDataSource _wrappee;

        public DataSourceDecorator(IDataSource wrappee)
        {
            _wrappee = wrappee;
        }

        public virtual void WriteData(string data)
        {
            _wrappee.WriteData(data);
        }

        public virtual string ReadData()
        {
            return _wrappee.ReadData();
        }
    }

    // Concrete Decorator: EncryptionDecorator
    class EncryptionDecorator : DataSourceDecorator
    {
        public EncryptionDecorator(IDataSource wrappee) : base(wrappee) { }

        public override void WriteData(string data)
        {
            string encryptedData = Encrypt(data);
            base.WriteData(encryptedData);
        }

        public override string ReadData()
        {
            string data = base.ReadData();
            return Decrypt(data);
        }

        private string Encrypt(string data)
        {
            Console.WriteLine("Encrypting data...");
            return $"Encrypted({data})";
        }

        private string Decrypt(string data)
        {
            Console.WriteLine("Decrypting data...");
            return data.Replace("Encrypted(", "").Replace(")", "");
        }
    }

    // Concrete Decorator: CompressionDecorator
    class CompressionDecorator : DataSourceDecorator
    {
        public CompressionDecorator(IDataSource wrappee) : base(wrappee) { }

        public override void WriteData(string data)
        {
            string compressedData = Compress(data);
            base.WriteData(compressedData);
        }

        public override string ReadData()
        {
            string data = base.ReadData();
            return Decompress(data);
        }

        private string Compress(string data)
        {
            Console.WriteLine("Compressing data...");
            return $"Compressed({data})";
        }

        private string Decompress(string data)
        {
            Console.WriteLine("Decompressing data...");
            return data.Replace("Compressed(", "").Replace(")", "");
        }
    }

    // Client
    class Application
    {
        public void DumbUsageExample()
        {
            IDataSource source = new FileDataSource("somefile.dat");
            source.WriteData("Salary records");

            source = new CompressionDecorator(source);
            source.WriteData("Salary records");

            source = new EncryptionDecorator(source);
            source.WriteData("Salary records");
        }
    }

    // Client
    class SalaryManager
    {
        private readonly IDataSource _source;

        public SalaryManager(IDataSource source)
        {
            _source = source;
        }

        public string Load()
        {
            return _source.ReadData();
        }

        public void Save(string salaryRecords)
        {
            _source.WriteData(salaryRecords);
        }
    }

    // Application Configurator
    class ApplicationConfigurator
    {
        public IDataSource ConfigurationExample(bool enabledEncryption, bool enabledCompression)
        {
            IDataSource source = new FileDataSource("salary.dat");

            if (enabledEncryption)
                source = new EncryptionDecorator(source);

            if (enabledCompression)
                source = new CompressionDecorator(source);

            return source;
        }
    }
}

using System;
using System.Reflection;

namespace ConfigurationBuilder.Readers
{
    public abstract class EmbeddedResourceReaderOptions
    {
        protected abstract Type ConfigType { get; }

        private Assembly _assembly;
        public Assembly Assembly => _assembly ?? (_assembly = ConfigType.Assembly);

        private IFileNameHandler _fileNameHandler;
        public IFileNameHandler FileNameHandler => _fileNameHandler ?? (_fileNameHandler = new FileNameHandler());

        public EmbeddedResourceReaderOptions FromAssembly(Assembly assembly)
        {
            _assembly = assembly;
            return this;
        }

        public EmbeddedResourceReaderOptions WithFileNameHandler(IFileNameHandler fileNameHandler)
        {
            _fileNameHandler = fileNameHandler;
            return this;
        }
    }

    public class EmbeddedResourceReaderOptions<T> : EmbeddedResourceReaderOptions
    {
        private Type _configType;
        protected override Type ConfigType => _configType ?? (_configType = typeof(T));
    }
}

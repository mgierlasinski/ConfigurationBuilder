namespace ConfigurationBuilder.Readers
{
    public class FileReaderOptions
    {
        private IFileNameHandler _fileNameHandler;
        public IFileNameHandler FileNameHandler => _fileNameHandler ?? (_fileNameHandler = new FileNameHandler());

        public FileReaderOptions WithFileNameHandler(IFileNameHandler fileNameHandler)
        {
            _fileNameHandler = fileNameHandler;
            return this;
        }
    }
}

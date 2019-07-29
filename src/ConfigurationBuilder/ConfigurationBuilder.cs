using System.Threading.Tasks;

namespace ConfigurationBuilder
{
    public class ConfigurationBuilder<T>
    {
        public IContentReader Reader { get; set; }
        public IContentProcessor<T> Processor { get; set; }

        public T Build()
        {
            var content = Reader.ReadContent();
            return Processor.ProcessContent(content);
        }

        public async Task<T> BuildAsync()
        {
            var content = await Reader.ReadContentAsync();
            return await Processor.ProcessContentAsync(content);
        }
    }
}
